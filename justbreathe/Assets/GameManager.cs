#pragma warning disable 0649

using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private KeyDisplay BreathKey;
    [SerializeField] private KeyDisplay HeartKey;

    // Start is called before the first frame update
    void Start()
    {
        BreathKey.SetInitalValues("F", 2.0f, 2.0f, InputStyle.UpDown, KeyCode.F);
        HeartKey.SetInitalValues("_", 1.0f, 1.0f, InputStyle.Impulse, KeyCode.Space);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
