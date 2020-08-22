#pragma warning disable 0649

using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeyDisplay : MonoBehaviour
{
    private const float HealthFillDown = .5f;
    private const float HealthFillUp = .25f;

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

    [Header("SFX")]
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioClip clip2;
    [SerializeField] private AudioPlayMode clipPlayMode;
    [SerializeField] private float volume = .5f;
    private AudioSource audioSource;

    [Header("Vars")]
    public string Key;
    public float FillAmount;
    public float TimeUp;
    public float TimeDown;
    public bool IsImpulse;
    public bool IsDown;
    private bool wasDown;
    public bool ShouldBeDown;
    public KeyCode KeyCode;

    private bool nextShouldBeDown;
    private Graph graph;
    private bool[] bufferedShouldBeDown;

    private void Awake()
    {
        graph = GetComponentInChildren<Graph>();
        bufferedShouldBeDown = new bool[graph.NumPoints];
        
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.playOnAwake = false;

        StartCoroutine(KeyTimer_Co());
        StartCoroutine(BufferedInput_Co());
    }

    private IEnumerator KeyTimer_Co()
    {
        nextShouldBeDown = false;
        while (true)
        {
            if (nextShouldBeDown) yield return new WaitForSeconds(TimeDown);
            else yield return new WaitForSeconds(TimeUp);
            nextShouldBeDown = !nextShouldBeDown;
        }
    }

    private IEnumerator BufferedInput_Co()
    {
        while (true)
        {
            for (int i = 0; i < bufferedShouldBeDown.Length - 1; i++)
                bufferedShouldBeDown[i] = bufferedShouldBeDown[i + 1];
            bufferedShouldBeDown[bufferedShouldBeDown.Length - 1] = nextShouldBeDown;
            ShouldBeDown = bufferedShouldBeDown[0];
            graph.SetPoints(bufferedShouldBeDown);

            yield return new WaitForSeconds(.05f);
        }
    }

    private void Update()
    {
        UpdateUI();
        UpdateAudio();

        wasDown = IsDown;
    }

    private void UpdateAudio()
    {
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
        keyText.text = Key;

        if (IsDown) keyStateImage.sprite = downArrow;
        else keyStateImage.sprite = upArrow;

        if (ShouldBeDown) keyTargetStateImage.sprite = downArrow;
        else keyTargetStateImage.sprite = upArrow;

        FillAmount = Mathf.Clamp01(FillAmount);
        fillTransform.sizeDelta = new Vector2(maxFillWidth * FillAmount, fillTransform.sizeDelta.y);

        IsDown = Input.GetKey(KeyCode);

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

    public void SetInitalValues(string keyName, float timeUp, float timeDown, bool impulse, UnityEngine.KeyCode key)
    {
        Key = keyName;
        TimeDown = timeDown;
        TimeUp = timeUp;
        IsImpulse = impulse;
        KeyCode = key;
    }
}

public enum AudioPlayMode { OnKeyStateChanged, OnKeyPressed, OnKeyStateChanged2Clip }