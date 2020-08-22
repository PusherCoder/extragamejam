using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeyDisplay : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI keyText;
    [SerializeField] private Image keyStateImage;
    [SerializeField] private Image keyTargetStateImage;
    [SerializeField] private RectTransform fillTransform;
    [SerializeField] private float maxFillWidth;

    [SerializeField] private Sprite upArrow;
    [SerializeField] private Sprite downArrow;

    [Header("Vars")]
    public string Key;
    public float FillAmount;
    public float TimeUp;
    public float TimeDown;
    public bool IsImpulse;
    public bool IsDown;
    public bool ShouldBeDown;

    private bool nextShouldBeDown;
    private Graph graph;
    private bool[] bufferedShouldBeDown;

    private void Awake()
    {
        graph = GetComponentInChildren<Graph>();
        bufferedShouldBeDown = new bool[graph.NumPoints];

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
        keyText.text = Key;

        if (IsDown) keyStateImage.sprite = downArrow;
        else keyStateImage.sprite = upArrow;

        if (ShouldBeDown) keyTargetStateImage.sprite = downArrow;
        else keyTargetStateImage.sprite = upArrow;

        FillAmount = Mathf.Clamp01(FillAmount);
        fillTransform.sizeDelta = new Vector2(maxFillWidth * FillAmount, fillTransform.sizeDelta.y);
    }

    public void SetInitalValues(string keyName, float timeUp, float timeDown, bool impulse)
    {
        Key = keyName;
        TimeDown = timeDown;
        TimeUp = timeUp;
        IsImpulse = impulse;
    }
}
