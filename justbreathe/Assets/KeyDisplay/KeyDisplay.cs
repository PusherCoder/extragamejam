#pragma warning disable 0649

using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeyDisplay : MonoBehaviour
{
    private const float HealthFillDown = .4f;
    private const float HealthFillUp = .2f;
    private const int ImpulseKeyForgiveness = 7;

    public bool Active;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI keyText;
    [SerializeField] private Image keyStateImage;
    [SerializeField] private Image keyTargetStateImage;
    [SerializeField] private RectTransform fillTransform;
    [SerializeField] private float maxFillWidth;

    [SerializeField] private Sprite upArrow;
    [SerializeField] private Sprite downArrow;
    [SerializeField] private Color correctColor;
    [SerializeField] private Color incorrectColor;

    [SerializeField] private CanvasGroup organCanvasGroup;

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

    private bool nextShouldBeDown;
    private Graph graph;
    private bool[] bufferedShouldBeDown;
    private bool[] bufferedShouldBeDownImpulse;

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

        canvasGroup = GetComponent<CanvasGroup>();
        if (Active)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            
            organCanvasGroup.alpha = 1;
            organCanvasGroup.interactable = true;
            organCanvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            organCanvasGroup.alpha = 0;
            organCanvasGroup.interactable = false;
            organCanvasGroup.blocksRaycasts = false;
        }

        StartCoroutine(KeyTimer_Co());
        StartCoroutine(BufferedInput_Co());
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
        }
        else
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, 0f, Time.deltaTime);
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            organCanvasGroup.alpha = canvasGroup.alpha;
            organCanvasGroup.interactable = false;
            organCanvasGroup.blocksRaycasts = false;
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
        if (Active == false || canvasGroup.alpha < .95f) return;

        if (IsDown) keyStateImage.sprite = downArrow;
        else keyStateImage.sprite = upArrow;

        if (ShouldBeDown) keyTargetStateImage.sprite = downArrow;
        else keyTargetStateImage.sprite = upArrow;

        FillAmount = Mathf.Clamp01(FillAmount);
        fillTransform.sizeDelta = new Vector2(maxFillWidth * FillAmount, fillTransform.sizeDelta.y);

        IsDown = Input.GetKey(Key);
    }

    private bool inKeyPressTime;
    private void UpdateHealth()
    {
        if (Active == false || canvasGroup.alpha < .95f) return;

        if (InputStyle == InputStyle.UpDown)
        {
            if (IsDown != ShouldBeDown)
            {
                FillAmount -= Time.deltaTime * HealthFillDown;
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
                FillAmount -= HealthFillDown;
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
                    FillAmount -= HealthFillDown;
                }
            }
        }
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