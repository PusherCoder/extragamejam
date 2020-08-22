using System.Collections;
using UnityEngine;
using TMPro;

public class KeyDisplay : MonoBehaviour
{
    private const float HealthFillDown = .5f;
    private const float HealthFillUp = .25f;

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
    public UnityEngine.KeyCode KeyCode;

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
            if (ShouldBeDown) TargetState = "Down";
            else TargetState = "Up";
        }
    }

    private void Update()
    {
        keyText.text = Key;
        keyStateText.text = KeyState;
        keyTargetStateText.text = TargetState;

        FillAmount = Mathf.Clamp01(FillAmount);
        fillTransform.sizeDelta = new Vector2(maxFillWidth * FillAmount, fillTransform.sizeDelta.y);

        if (Input.GetKey(KeyCode)) KeyState = "Down";
        else KeyState = "Up";

        //Maybe just decrease the health a little bit every frame?
        if (KeyState != TargetState)
            FillAmount -= Time.deltaTime * HealthFillDown;
        else
            FillAmount += Time.deltaTime * HealthFillUp;
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
