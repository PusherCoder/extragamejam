#pragma warning disable 0649

using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private KeyDisplay EKey;
    [SerializeField] private KeyDisplay FKey;

    // Start is called before the first frame update
    void Start()
    {
        EKey.SetInitalValues("E", 2.0f, 2.0f, false, KeyCode.E);
        FKey.SetInitalValues("F", 1.0f, 1.0f, false, KeyCode.F);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
