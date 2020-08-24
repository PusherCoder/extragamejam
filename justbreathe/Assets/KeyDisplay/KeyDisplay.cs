#pragma warning disable 0649

using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class KeyDisplay : MonoBehaviour
{
    private const int ImpulseKeyForgiveness = 5;
    private const float DontTakeInputTime = .5f;

    public UnityEvent OnFail = new UnityEvent();

    public bool Active;

    [Header("UI")]
    [SerializeField] private Image keyStateImage;
    [SerializeField] private Image keyTargetStateImage;
    [SerializeField] private RectTransform fillTransform;
    [SerializeField] private float maxFillWidth;

    [SerializeField] private Sprite upArrow;
    [SerializeField] private Sprite downArrow;
    [SerializeField] private Color correctColor;
    [SerializeField] private Color incorrectColor;

    [SerializeField] private CanvasGroup organCanvasGroup;
    [SerializeField] private CanvasGroup lineCanvasGroup;

    [Header("SFX")]
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioClip clip2;
    [SerializeField] private AudioPlayMode clipPlayMode;
    [SerializeField] private float volume = .5f;
    private AudioSource audioSource;

    [Header("Vars")]
    public InputStyle InputStyle;
    private bool graphImpulseBuffered = false;

    public string KeyName;
    public float FillAmount;
    public float TimeUp;
    public float TimeDown;
    public bool IsDown;
    private bool wasDown;
    public bool ShouldBeDown;
    public KeyCode Key;
    public float HealthFillDown = .4f;
    public float HealthFillUp = .2f;

    private bool nextShouldBeDown;
    private Graph graph;
    private bool[] bufferedShouldBeDown;
    private bool[] bufferedShouldBeDownImpulse;
    private float impulseInvincibility;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        graph = GetComponentInChildren<Graph>();
        bufferedShouldBeDown = new bool[graph.NumPoints];
        bufferedShouldBeDownImpulse = new bool[graph.NumPoints + ImpulseKeyForgiveness];
        
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.playOnAwake = false;

        FillAmount = 1f;

        canvasGroup = GetComponent<CanvasGroup>();
        if (Active)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            
            organCanvasGroup.alpha = 1;
            organCanvasGroup.interactable = true;
            organCanvasGroup.blocksRaycasts = true;

            lineCanvasGroup.alpha = 1;
            lineCanvasGroup.interactable = true;
            lineCanvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            organCanvasGroup.alpha = 0;
            organCanvasGroup.interactable = false;
            organCanvasGroup.blocksRaycasts = false;

            lineCanvasGroup.alpha = 0;
            lineCanvasGroup.interactable = false;
            lineCanvasGroup.blocksRaycasts = false;
        }

        StartCoroutine(KeyTimer_Co());
        StartCoroutine(BufferedInput_Co());
    }

    private float timeSinceStartup;
    private void Start()
    {
        timeSinceStartup = 0;
    }

    private IEnumerator KeyTimer_Co()
    {
        nextShouldBeDown = false;
        while (true)
        {
            if (InputStyle == InputStyle.UpDown)
            {
                if (nextShouldBeDown) yield return new WaitForSeconds(TimeDown);
                else yield return new WaitForSeconds(TimeUp);
                nextShouldBeDown = !nextShouldBeDown;
            }
            else if (InputStyle == InputStyle.Impulse)
            {
                yield return new WaitForSeconds(TimeDown);
                graphImpulseBuffered = true;
            }
        }
    }

    private IEnumerator BufferedInput_Co()
    {
        while (true)
        {
            for (int i = 0; i < bufferedShouldBeDown.Length - 1; i++)
            {
                bufferedShouldBeDown[i] = bufferedShouldBeDown[i + 1];
                bufferedShouldBeDownImpulse[i] = bufferedShouldBeDownImpulse[i + 1];
            }

            if (InputStyle == InputStyle.UpDown)
                bufferedShouldBeDown[bufferedShouldBeDown.Length - 1] = nextShouldBeDown;
            else
            {
                bufferedShouldBeDown[bufferedShouldBeDown.Length - 1] = graphImpulseBuffered;
                bufferedShouldBeDownImpulse[bufferedShouldBeDown.Length - 1] = graphImpulseBuffered;
            }
            graphImpulseBuffered = false;

            ShouldBeDown = bufferedShouldBeDown[0];
      
            graph.SetPoints(bufferedShouldBeDown);

            yield return new WaitForSeconds(.05f);
        }
    }

    private void Update()
    {
        if (GameManager.HaveFailedScenario || GameManager.HaveBeatScenario) return;

        CheckActive();
        UpdateUI();
        UpdateHealth();
        UpdateAudio();

        wasDown = IsDown;
    }

    private void CheckActive()
    {
        if (Active)
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, 1f, Time.deltaTime);
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            organCanvasGroup.alpha = canvasGroup.alpha;
            organCanvasGroup.interactable = true;
            organCanvasGroup.blocksRaycasts = true;

            lineCanvasGroup.alpha = canvasGroup.alpha;
            lineCanvasGroup.interactable = true;
            lineCanvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, 0f, Time.deltaTime);
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            organCanvasGroup.alpha = canvasGroup.alpha;
            organCanvasGroup.interactable = false;
            organCanvasGroup.blocksRaycasts = false;

            lineCanvasGroup.alpha = canvasGroup.alpha;
            lineCanvasGroup.interactable = false;
            lineCanvasGroup.blocksRaycasts = false;
        }
    }

    private void UpdateAudio()
    {
        if (Active == false || canvasGroup.alpha < .95f) return;
        if (clip == null) return;
        if (clip2 == null && clipPlayMode == AudioPlayMode.OnKeyStateChanged2Clip) return;
        if (audioSource == null) return;

        if ((clipPlayMode == AudioPlayMode.OnKeyStateChanged) && (wasDown != IsDown))
            audioSource.Play();
        else if ((clipPlayMode == AudioPlayMode.OnKeyPressed) && wasDown == false && IsDown == true)
            audioSource.Play();
        else if ((clipPlayMode == AudioPlayMode.OnKeyStateChanged2Clip) && wasDown == false && IsDown == true)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else if ((clipPlayMode == AudioPlayMode.OnKeyStateChanged2Clip) && wasDown == true && IsDown == false)
        {
            audioSource.clip = clip2;
            audioSource.Play();
        }
    }

    private void UpdateUI()
    {
        FillAmount = Mathf.Clamp01(FillAmount);
        fillTransform.sizeDelta = new Vector2(maxFillWidth * FillAmount, fillTransform.sizeDelta.y);

        if (Active == false || canvasGroup.alpha < .95f) return;

        timeSinceStartup += Time.deltaTime;
        if (timeSinceStartup < DontTakeInputTime) return;

        if (IsDown) keyStateImage.sprite = downArrow;
        else keyStateImage.sprite = upArrow;

        if (ShouldBeDown) keyTargetStateImage.sprite = downArrow;
        else keyTargetStateImage.sprite = upArrow;

        IsDown = Input.GetKey(Key);
    }

    private bool inKeyPressTime;
    private void UpdateHealth()
    {
        float difficultyMod = 4f / (GameManager.AdaptiveDifficulty + 4f);

        impulseInvincibility -= Time.deltaTime;

        if (Active == false || canvasGroup.alpha < .95f || timeSinceStartup < DontTakeInputTime)
        {
            FillAmount = 1f;
            return;
        }

        if (InputStyle == InputStyle.UpDown)
        {
            if (IsDown != ShouldBeDown)
            {
                FillAmount -= Time.deltaTime * HealthFillDown * difficultyMod;
                keyStateImage.color = incorrectColor;
            }
            else
            {
                FillAmount += Time.deltaTime * HealthFillUp;
                keyStateImage.color = correctColor;
            }
        }
        else if (InputStyle == InputStyle.Impulse)
        {
            FillAmount += Time.deltaTime * HealthFillUp;

            bool foundKeyPressRequired = false;
            for (int i = 0; i < ImpulseKeyForgiveness * 2; i++)
                foundKeyPressRequired = foundKeyPressRequired || bufferedShouldBeDownImpulse[i];

            if (foundKeyPressRequired && inKeyPressTime == false)
                inKeyPressTime = true;
            else if (foundKeyPressRequired == false && inKeyPressTime)
            {
                inKeyPressTime = false;

                if (impulseInvincibility < 0f)
                {
                    FillAmount -= HealthFillDown * difficultyMod;
                    impulseInvincibility = .15f;
                }
            }

            if (Input.GetKeyDown(Key))
            {
                if (inKeyPressTime)
                {
                    for (int i = 0; i < ImpulseKeyForgiveness*2; i++)
                        bufferedShouldBeDownImpulse[i] = false;
                    inKeyPressTime = false;
                }
                else
                {
                    if (impulseInvincibility < 0f)
                    {
                        FillAmount -= HealthFillDown * difficultyMod;
                        impulseInvincibility = .15f;
                    }
                }
            }
        }

        if (FillAmount <= 0f) OnFail.Invoke();
    }

    public void SetInitalValues(string keyName, float timeUp, float timeDown, InputStyle inputStyle, KeyCode key)
    {
        KeyName = keyName;
        TimeDown = timeDown;
        TimeUp = timeUp;
        InputStyle = inputStyle;
        Key = key;
    }
}

public enum AudioPlayMode { OnKeyStateChanged, OnKeyPressed, OnKeyStateChanged2Clip }
public enum InputStyle { UpDown, Impulse }