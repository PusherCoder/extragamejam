#pragma warning disable 0649

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool HaveFailedScenario = false;
    public static int Level = 2;

    [Header("General Game Elements")]
    [SerializeField] private KeyDisplay BreathKey;
    [SerializeField] private KeyDisplay HeartKey;
    [SerializeField] private UnityEngine.UI.Text Subtitles;
    [SerializeField] private CanvasGroup deathScreenCanvasGroup;
    [SerializeField] private Text deathScreenText;
    [SerializeField] private Image holdSpaceImage;
    [SerializeField] private AudioLowPassFilter lowPass;
    [SerializeField] private UnityEngine.UI.Image ManMan;
    [SerializeField] private UnityEngine.UI.Image Background;

    [Header("Scenario 1 Data")]
    public AudioClip VO1Monday;
    public AudioClip VO1Ceiling;
    public AudioClip VO1Keyboard;
    public AudioClip VO1Faster;
    public AudioClip VO1Slower;
    public AudioClip VO1Focus;
    public AudioClip VO1Heartbeat;
    public Sprite ManMan1;
    public Sprite Background1;

    [Header("Scenario 2 Data")]
    public AudioClip VO2Cereal;
    public AudioClip VO2Sugar;
    public AudioClip VO2Power;
    public AudioClip VO2Forgotten;
    public AudioClip VO2Saturday;
    public AudioClip VO2Drink;
    public AudioClip VO2Papers;
    public Sprite ManMan2;
    public Sprite Background2;

    private GameScriptController[] ScenarioGameScript;
    private float ScenarioTime;
    private int ScenarioPosition;
    private AudioSource ScenarioAudio;
    private bool fadeInDeathScreen = false;

    private void Start()
    {
        BreathKey.SetInitalValues("F", 2.0f, 2.0f, InputStyle.UpDown, KeyCode.F);
        HeartKey.SetInitalValues("_", 1.0f, 1.0f, InputStyle.Impulse, KeyCode.Space);
        BreathKey.OnFail.AddListener(Asphyxiate);
        HeartKey.OnFail.AddListener(HeartAttack);

        ScenarioTime = 0f;
        ScenarioPosition = -1;
        ScenarioAudio = gameObject.AddComponent<AudioSource>();
        ScenarioAudio.playOnAwake = false;

        if (Level == 1) LoadLevel1();
        else if (Level == 2) LoadLevel2();

        deathScreenCanvasGroup.alpha = 0;
        lowPass.cutoffFrequency = 22000;
        HaveFailedScenario = false;
    }

    private void LoadLevel1()
    {
        ScenarioGameScript = Scenarios.GetLevel1Script(this, HeartKey);
        Background.sprite = Background1;
        ManMan.sprite = ManMan1;
    }

    private void LoadLevel2()
    {
        ScenarioGameScript = Scenarios.GetLevel2Script(this, HeartKey, BreathKey);
        Background.sprite = Background2;
        ManMan.sprite = ManMan2;
    }
    
    private void Asphyxiate()
    {
        if (fadeInDeathScreen) return;

        deathScreenText.text = "you asphyxiated :'(\nhold space to retry";
        fadeInDeathScreen = true;
        HaveFailedScenario = true;
    }

    private void HeartAttack()
    {
        if (fadeInDeathScreen) return;

        deathScreenText.text = "you died of a heart attack\nhold space to retry";
        fadeInDeathScreen = true;
        HaveFailedScenario = true;
    }

    private void Update()
    {
        FadeInDeathScreen();
        
        if(ScenarioPosition == -1 || ScenarioTime > ScenarioGameScript[ScenarioPosition].ScenarioTime )
        {
            ScenarioPosition++;
            Subtitles.text = ScenarioGameScript[ScenarioPosition].Subtitle;
            if( ScenarioGameScript[ScenarioPosition].VOClip != null )
            {
                ScenarioAudio.clip = ScenarioGameScript[ScenarioPosition].VOClip;
                ScenarioAudio.volume = ScenarioGameScript[ScenarioPosition].Volume;
                ScenarioAudio.Play();
            }

            if (ScenarioGameScript[ScenarioPosition].HeartEnabled) HeartKey.Active = true;
            if (ScenarioGameScript[ScenarioPosition].LungsEnabled) BreathKey.Active = true;

            if (ScenarioGameScript[ScenarioPosition].Adjustment != null)
            {
                for (int i = 0; i < ScenarioGameScript[ScenarioPosition].Adjustment.Length; i++)
                {
                    ScenarioGameScript[ScenarioPosition].Adjustment[i].Key.TimeDown = ScenarioGameScript[ScenarioPosition].Adjustment[i].TimeDown;
                    ScenarioGameScript[ScenarioPosition].Adjustment[i].Key.TimeUp = ScenarioGameScript[ScenarioPosition].Adjustment[i].TimeUp;
                }
            }
        }
        ScenarioTime += Time.deltaTime;
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

        lowPass.cutoffFrequency = Mathf.Lerp(lowPass.cutoffFrequency, 500, Time.deltaTime);
    }
}
