using System.Collections;
using UnityEngine;
using TMPro;

public class KeyDisplay : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI keyText;
    [SerializeField] private TextMeshProUGUI keyStateText;
    [SerializeField] private TextMeshProUGUI keyTargetStateText;
    [SerializeField] private RectTransform fillTransform;
    [SerializeField] private float maxFillWidth;

    [Header("Vars")]
    public string Key;
    public string KeyState;
    public string TargetState;
    public float FillAmount;
    public float TimeUp;
    public float TimeDown;
    public bool IsImpulse;
    public bool ShouldBeDown;

    private void Awake()
    {
        StartCoroutine(KeyTimer_Co());
    }

    private IEnumerator KeyTimer_Co()
    {
        ShouldBeDown = false;
        while (true)
        {
            if (ShouldBeDown) yield return new WaitForSeconds(TimeDown);
            else yield return new WaitForSeconds(TimeUp);
            ShouldBeDown = !ShouldBeDown;
        }
    }

    private void Update()
    {
        keyText.text = Key;
        keyStateText.text = KeyState;
        keyTargetStateText.text = TargetState;

        FillAmount = Mathf.Clamp01(FillAmount);
        fillTransform.sizeDelta = new Vector2(maxFillWidth * FillAmount, fillTransform.sizeDelta.y);
    }
}
