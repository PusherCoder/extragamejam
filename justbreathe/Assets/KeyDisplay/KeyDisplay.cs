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

    private void Update()
    {
        keyText.text = Key;
        keyStateText.text = KeyState;
        keyTargetStateText.text = TargetState;

        FillAmount = Mathf.Clamp01(FillAmount);
        fillTransform.sizeDelta = new Vector2(maxFillWidth * FillAmount, fillTransform.sizeDelta.y);
    }
}
