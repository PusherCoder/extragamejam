using UnityEngine;
using UnityEngine.UI;

public class Blur : MonoBehaviour
{
    private static Blur instance;

    [SerializeField] private Material myMaterial;

    private void Awake()
    {
        instance = this;
        SetBlurAmount(0f);
    }

    public static void SetBlurAmount(float amount)
    {
        instance.myMaterial.SetFloat("_Radius", amount);
    }
}
