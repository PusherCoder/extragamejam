#pragma warning disable 0649

using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] private CanvasGroup patientInfoCanvasGroup;
    [SerializeField] private CanvasGroup medicalTextbookCanvasGroup;
    [SerializeField] private CanvasGroup herbloreTextbookCanvasGroup;

    [Header("Potion Recipe")]
    [SerializeField] private TextMeshProUGUI reagentsText;
    [SerializeField] private TMP_InputField newIngredientInputField;

    private void Awake()
    {
        Hide(patientInfoCanvasGroup);
        Hide(medicalTextbookCanvasGroup);
        Hide(herbloreTextbookCanvasGroup);
    }

    #region Info UI
    private void Show(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    private void Hide(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    private bool IsVisible(CanvasGroup canvasGroup) => canvasGroup.alpha > .5f;

    private void Toggle(CanvasGroup canvasGroup)
    {
        if (IsVisible(canvasGroup)) Hide(canvasGroup);
        else Show(canvasGroup);
    }

    public void TogglePatientInfo()
    {
        Toggle(patientInfoCanvasGroup);
        Hide(medicalTextbookCanvasGroup);
        Hide(herbloreTextbookCanvasGroup);
    }

    public void ToggleMedicalTextbook()
    {
        Hide(patientInfoCanvasGroup);
        Toggle(medicalTextbookCanvasGroup);
        Hide(herbloreTextbookCanvasGroup);
    }

    public void ToggleHerbloreTextbook()
    {
        Hide(patientInfoCanvasGroup);
        Hide(medicalTextbookCanvasGroup);
        Toggle(herbloreTextbookCanvasGroup);
    }
    #endregion

    #region Potion Recipe
    public void AddReagent()
    {
        string newIngredientText = newIngredientInputField.text;
        newIngredientText = newIngredientText.ToLower();
        newIngredientText = newIngredientText.Trim();

        switch (newIngredientText)
        {
            case "king's root":
            case "kings root":
                GameManager.Instance.ActivePotion.KingsRoot++;
                break;
            case "soothe weed":
                GameManager.Instance.ActivePotion.SootheWeed++;
                break;
            case "arrow root":
                GameManager.Instance.ActivePotion.ArrowRoot++;
                break;
            case "kobold's tooth":
            case "kobolds tooth":
                GameManager.Instance.ActivePotion.KoboldsTooth++;
                break;
            default:
                Debug.LogError($"Unknown ingredient {newIngredientText}");
                break;
        }

        newIngredientInputField.Select();
        newIngredientInputField.text = "";

        reagentsText.text = GameManager.Instance.ActivePotion.ToString();
    }
    #endregion
}
