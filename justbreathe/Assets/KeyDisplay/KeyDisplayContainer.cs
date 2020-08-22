using UnityEngine;

public class KeyDisplayContainer : MonoBehaviour
{
    private static KeyDisplayContainer instance;
    private static KeyDisplay keyDisplay;

    [SerializeField] private KeyDisplay keyDisplayPrefab;

    private void Awake()
    {
        instance = this;
    }

    public static KeyDisplay CreateKeyDisplay(string keyName, float timeUp, float timeDown, bool impulse)
    {
        keyDisplay = Instantiate(instance.keyDisplayPrefab, instance.transform);
        keyDisplay.Key        = keyName;
        keyDisplay.TimeDown   = timeDown;
        keyDisplay.TimeUp     = timeUp;
        keyDisplay.IsImpulse  = impulse;

        return keyDisplay;
    }
}
