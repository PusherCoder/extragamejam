﻿#pragma warning disable 0649

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool HaveFailedScenario = false;
    public static bool HaveBeatScenario = false;
    public static int Level = 4;

    public static int AdaptiveDifficulty = 0;

    [Header("General Game Elements")]
    [SerializeField] private KeyDisplay BreathKey;
    [SerializeField] private KeyDisplay HeartKey;
    [SerializeField] private KeyDisplay EyeKey;
    [SerializeField] private KeyDisplay IntestinesKey;
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
    public AudioClip VO2Crunching1;
    public AudioClip VO2Sugar;
    public AudioClip VO2Crunching2;
    public AudioClip VO2Drink;
    public AudioClip VO2Power;
    public AudioClip VO2Papers;
    public AudioClip VO2Forgotten;
    public AudioClip VO2Saturday;
    public AudioClip VO2Crunching3;
    public Sprite ManMan2;
    public Sprite Background2;

    [Header("Scenario 3 Data")]
    public AudioClip VO3HeavyBreathing;
    public AudioClip VO3Running;
    public AudioClip VO3She;
    public AudioClip VO3Choking;
    public AudioClip VO3Bug;
    public AudioClip VO3Breathing2;
    public AudioClip VO3Eyes;
    public AudioClip VO3Gasping;
    public AudioClip VO3Up;
    public AudioClip VO3Gasping2;
    public AudioClip VO3CallMe;
    public Sprite ManMan3;
    public Sprite Background3;

    [Header("Scenario 4 Data")]
    public AudioClip VO4Burrito;
    public AudioClip VO4Typing1;
    public AudioClip VO4Stomach;
    public AudioClip VO4Typing2;
    public AudioClip VO4Report;
    public AudioClip VO4JustFine;
    public AudioClip VO4Postpone;
    public AudioClip VO4OhGod;
    public AudioClip VO4NoProblem;
    public AudioClip VO4Friend;
    public AudioClip VO4He;
    public AudioClip VO4Cool;
    public AudioClip VO4Please;
    public AudioClip VO4NextWeekend;
    public AudioClip VO4Maybe;
    public AudioClip ShitPants;
    public Sprite ManMan4;
    public Sprite Background4;

    private GameScriptController[] ScenarioGameScript;
    private float ScenarioTime;
    private int ScenarioPosition;
    private AudioSource ScenarioAudio;
    private bool fadeInDeathScreen = false;
    private bool fadeInVictoryScreen = false;

    private void Start()
    {
        BreathKey.SetInitalValues("F", 2.0f, 2.0f, InputStyle.UpDown, KeyCode.F);
        HeartKey.SetInitalValues("_", 1.0f, 1.0f, InputStyle.Impulse, KeyCode.Space);
        EyeKey.SetInitalValues("J", 5.0f, 5.0f, InputStyle.Impulse, KeyCode.J);
        IntestinesKey.SetInitalValues("K", 3.0f, 3.0f, InputStyle.UpDown, KeyCode.K);
        EyeKey.HealthFillUp = .05f;
        BreathKey.OnFail.AddListener(Asphyxiate);
        HeartKey.OnFail.AddListener(HeartAttack);
        IntestinesKey.OnFail.AddListener(ShartAttack);

        ScenarioTime = 0f;
        ScenarioPosition = -1;
        ScenarioAudio = gameObject.AddComponent<AudioSource>();
        ScenarioAudio.playOnAwake = false;

        if (Level == 1) LoadLevel1();
        else if (Level == 2) LoadLevel2();
        else if (Level == 3) LoadLevel3();
        else if (Level == 4) LoadLevel4();
        else ThanksForPlaying();

        deathScreenCanvasGroup.alpha = 0;
        lowPass.cutoffFrequency = 22000;
        HaveFailedScenario = false;
        HaveBeatScenario = false;
    }

    private void ThanksForPlaying()
    {
        SceneManager.LoadScene("ThanksForPlaying");
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

    private void LoadLevel3()
    {
        ScenarioGameScript = Scenarios.GetLevel3Script(this, HeartKey, BreathKey, EyeKey);
        Background.sprite = Background3;
        ManMan.sprite = ManMan3;
    }

    private void LoadLevel4()
    { 
        ScenarioGameScript = Scenarios.GetLevel4Script(this, HeartKey, BreathKey, EyeKey, IntestinesKey);
        Background.sprite = Background4;
        ManMan.sprite = ManMan4;
    }
    
    private void Asphyxiate()
    {
        if (fadeInDeathScreen) return;

        deathScreenText.text = "you asphyxiated :'(\nhold space to retry";
        fadeInDeathScreen = true;
        HaveFailedScenario = true;

        AdaptiveDifficulty++;
    }

    private void HeartAttack()
    {
        if (fadeInDeathScreen) return;

        deathScreenText.text = "you died of a heart attack\nhold space to retry";
        fadeInDeathScreen = true;
        HaveFailedScenario = true;

        AdaptiveDifficulty++;
    }

    private void ShartAttack()
    {
        if (fadeInDeathScreen) return;

        AudioSource shitSFX = gameObject.AddComponent<AudioSource>();
        shitSFX.clip = ShitPants;
        shitSFX.playOnAwake = false;
        shitSFX.volume = .5f;
        shitSFX.Play();

        deathScreenText.text = "you shat yourself\nhold space to retry";
        fadeInDeathScreen = true;
        HaveFailedScenario = true;

        AdaptiveDifficulty++;
    }

    private void Update()
    {
        FadeInDeathScreen();
        FadeInVictoryScreen();
        EyeBlurriness();

        if (fadeInDeathScreen || fadeInVictoryScreen) return;

        if(ScenarioPosition == -1 || ScenarioTime > ScenarioGameScript[ScenarioPosition].ScenarioTime)
        {
            ScenarioPosition++;

            if (ScenarioPosition >= ScenarioGameScript.Length)
            {
                fadeInVictoryScreen = true;
                HaveBeatScenario = true;
                return;
            }

            Subtitles.text = ScenarioGameScript[ScenarioPosition].Subtitle;
            if( ScenarioGameScript[ScenarioPosition].VOClip != null )
            {
                ScenarioAudio.clip = ScenarioGameScript[ScenarioPosition].VOClip;
                ScenarioAudio.volume = ScenarioGameScript[ScenarioPosition].Volume;
                ScenarioAudio.Play();
            }

            if (ScenarioGameScript[ScenarioPosition].HeartEnabled) HeartKey.Active = true;
            if (ScenarioGameScript[ScenarioPosition].LungsEnabled) BreathKey.Active = true;
            if (ScenarioGameScript[ScenarioPosition].EyesEnabled) EyeKey.Active = true;
            if (ScenarioGameScript[ScenarioPosition].IntestinesEnabled) IntestinesKey.Active = true;

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

    private void EyeBlurriness()
    {
        if (EyeKey.Active == false) return;
        if (HaveBeatScenario || HaveFailedScenario) return;

        float blurAmount = Mathf.Lerp(15f, 0f, EyeKey.FillAmount);
        Blur.SetBlurAmount(blurAmount);
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

    private void FadeInVictoryScreen()
    {
        if (fadeInVictoryScreen == false) return;

        AdaptiveDifficulty = 0;

        deathScreenText.text = "scene finished \nhold space to continue";

        deathScreenCanvasGroup.alpha += Time.deltaTime;
        deathScreenCanvasGroup.alpha = Mathf.Clamp01(deathScreenCanvasGroup.alpha);
        Blur.SetBlurAmount(deathScreenCanvasGroup.alpha * 25f);

        if (Input.GetKey(KeyCode.Space))
            restartAmount += Time.deltaTime * 2f;
        else
            restartAmount -= Time.deltaTime;

        holdSpaceImage.fillAmount = restartAmount;

        if (restartAmount >= 1f)
        {
            Level++;
            if (Level > 4) ThanksForPlaying();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        restartAmount = Mathf.Clamp01(restartAmount);

        lowPass.cutoffFrequency = Mathf.Lerp(lowPass.cutoffFrequency, 500, Time.deltaTime);
    }
}
