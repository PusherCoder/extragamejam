using UnityEngine;

public class KeyDisplayContainer : MonoBehaviour
{
    private static KeyDisplayContainer instance;

    [SerializeField] private KeyDisplay keyDisplayPrefab;

    private void Awake()
    {
        instance = this;
    }

    public static KeyDisplay CreateKeyDisplay(string keyName)
    {
        KeyDisplay keyDisplay = Instantiate(instance.keyDisplayPrefab, instance.transform);
        keyDisplay.Key = keyName;

        return keyDisplay;
    }
}
