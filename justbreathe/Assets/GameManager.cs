#pragma warning disable 0649

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private struct RhythmAdjustment
    {
        public KeyDisplay Key;
        public float TimeUp;
        public float TimeDown;
    }

    private struct GameScriptController
    {
        public float ScenarioTime;
        public string Subtitle;
        public RhythmAdjustment[] Adjustment;
    }

    [SerializeField] private KeyDisplay BreathKey;
    [SerializeField] private KeyDisplay HeartKey;
    [SerializeField] private UnityEngine.UI.Text Subtitles;
    [SerializeField] private CanvasGroup deathScreenCanvasGroup;
    [SerializeField] private Text deathScreenText;
    [SerializeField] private Image holdSpaceImage;

    private GameScriptController[] Scenario1;
    private float ScenarioTime;
    private int ScenarioPosition;
    private bool fadeInDeathScreen = false;

    private void Start()
    {
        BreathKey.SetInitalValues("F", 2.0f, 2.0f, InputStyle.UpDown, KeyCode.F);
        HeartKey.SetInitalValues("_", 1.0f, 1.0f, InputStyle.Impulse, KeyCode.Space);
        BreathKey.OnFail.AddListener(Asphyxiate);
        HeartKey.OnFail.AddListener(HeartAttack);

        deathScreenCanvasGroup.alpha = 0;
        ScenarioTime = 0.0f;
        ScenarioPosition = 0;

        Scenario1 = new GameScriptController[]
        {
            new GameScriptController{ ScenarioTime = 10.0f, Subtitle = "", Adjustment = new RhythmAdjustment[]{ new RhythmAdjustment{ Key = BreathKey, TimeDown = 1.0f, TimeUp = 1.0f } } },
            new GameScriptController{ ScenarioTime = 100.0f, Subtitle = "Feeling Dizzy", Adjustment = new RhythmAdjustment[]{ new RhythmAdjustment{ Key = BreathKey, TimeDown = 0.25f, TimeUp = 0.25f } } }
        };
    }
    
    private void Asphyxiate()
    {
        if (fadeInDeathScreen) return;

        deathScreenText.text = "you asphyxiated :'(\nhold space to retry";
        fadeInDeathScreen = true;
    }

    private void HeartAttack()
    {
        if (fadeInDeathScreen) return;

        deathScreenText.text = "you died of a heart attack\nhold space to retry";
        fadeInDeathScreen = true;
    }

    private void Update()
    {
        FadeInDeathScreen();
        
        ScenarioTime += Time.deltaTime;
        if( ScenarioTime > Scenario1[ScenarioPosition].ScenarioTime )
        {
            ScenarioPosition++;
            ScenarioTime = Scenario1[ScenarioPosition].ScenarioTime;
            for( int i = 0; i < Scenario1[ScenarioPosition].Adjustment.Length; i++ )
            {
                Subtitles.text = Scenario1[ScenarioPosition].Subtitle;
                Scenario1[ScenarioPosition].Adjustment[i].Key.TimeDown = Scenario1[ScenarioPosition].Adjustment[i].TimeDown;
                Scenario1[ScenarioPosition].Adjustment[i].Key.TimeUp = Scenario1[ScenarioPosition].Adjustment[i].TimeUp;
            }
        }
    }

    private float restartAmount;
    private void FadeInDeathScreen()
    { 
        if (fadeInDeathScreen == false) return;

        deathScreenCanvasGroup.alpha += Time.deltaTime;
        deathScreenCanvasGroup.alpha = Mathf.Clamp01(deathScreenCanvasGroup.alpha);
        Blur.SetBlurAmount(deathScreenCanvasGroup.alpha * 25f);

        if (Input.GetKey(KeyCode.Space))
            restartAmount += Time.deltaTime * 2f;
        else
            restartAmount -= Time.deltaTime;

        holdSpaceImage.fillAmount = restartAmount;

        if (restartAmount >= 1f)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        restartAmount = Mathf.Clamp01(restartAmount);
    }
}
