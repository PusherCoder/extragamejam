#pragma warning disable 0649

using UnityEngine;

public class UIBob : MonoBehaviour
{
    [SerializeField] private float bobAmount = 10f;
    [SerializeField] private float bobSpeed = .5f;

    private RectTransform rectTransform;
    private float initialYPosition;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        initialYPosition = rectTransform.anchoredPosition.y;
    }

    private void Update()
    {
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 
            initialYPosition + (Mathf.Sin(Time.time * bobSpeed) * bobAmount));

    }
}
