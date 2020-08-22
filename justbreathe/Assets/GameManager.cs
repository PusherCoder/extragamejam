using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const float ETimeInit = 1.0f;
    private const float FTimeInit = 2.0f;
    private const float HealthFillDown = .5f;
    private const float HealthFillUp = .25f;
    private const float HealthTimeInit = 0.4f;

    private float ETimeDown;
    private float ETimeUp;
    private float FTimeDown;
    private float FTimeUp;
    private float HealthCheck;
    private KeyDisplay EKey;
    private KeyDisplay FKey;

    // Start is called before the first frame update
    void Start()
    {
        EKey = KeyDisplayContainer.CreateKeyDisplay("E", 1.0f, 1.0f, false);
        FKey = KeyDisplayContainer.CreateKeyDisplay("F", 2.0f, 2.0f, false);

        HealthCheck = HealthTimeInit;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKey(KeyCode.E) ) EKey.KeyState = "Down";
        else EKey.KeyState = "Up";

        if(Input.GetKey(KeyCode.F))  FKey.KeyState = "Down";
        else FKey.KeyState = "Up";

        if(EKey.ShouldBeDown) EKey.TargetState = "Down";
        else EKey.TargetState = "Up";

        if(FKey.ShouldBeDown)  FKey.TargetState = "Down";
        else FKey.TargetState = "Up";


        //Maybe just decrease the health a little bit every frame?
        if (EKey.KeyState != EKey.TargetState)
            EKey.FillAmount -= Time.deltaTime * HealthFillDown;
        else
            EKey.FillAmount += Time.deltaTime * HealthFillUp;

        if (FKey.KeyState != FKey.TargetState)
            FKey.FillAmount -= Time.deltaTime * HealthFillDown;
        else
            FKey.FillAmount += Time.deltaTime * HealthFillUp;
    }
}
