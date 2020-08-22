#pragma warning disable 0649

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private KeyDisplay BreathKey;
    [SerializeField] private KeyDisplay HeartKey;

    [SerializeField] private CanvasGroup deathScreenCanvasGroup;
    [SerializeField] private Text deathScreenText;
    [SerializeField] private Image holdSpaceImage;
    private bool fadeInDeathScreen = false;

    private void Start()
    {
        BreathKey.SetInitalValues("F", 2.0f, 2.0f, InputStyle.UpDown, KeyCode.F);
        HeartKey.SetInitalValues("_", 1.0f, 1.0f, InputStyle.Impulse, KeyCode.Space);

        BreathKey.OnFail.AddListener(Asphyxiate);
        HeartKey.OnFail.AddListener(HeartAttack);

        deathScreenCanvasGroup.alpha = 0;
    }

    private void Asphyxiate()
    {
        if (fadeInDeathScreen) return;

        deathScreenText.text = "you asphyxiated :'(\nhold space to retry";
        fadeInDeathScreen = true;
    }

    private void HeartAttack()
    {
        if (fadeInDeathScreen) return;

        deathScreenText.text = "you died of a heart attack\nhold space to retry";
        fadeInDeathScreen = true;
    }

    private void Update()
    {
        FadeInDeathScreen();
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
    }
}
