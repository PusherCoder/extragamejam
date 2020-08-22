using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private const float ETimeInit = 1.0f;
    private const float FTimeInit = 2.0f;
    private const float HealthFillDown = 0.02f;
    private const float HealthFillUp = 0.01f;
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
        EKey = KeyDisplayContainer.CreateKeyDisplay("E");
        FKey = KeyDisplayContainer.CreateKeyDisplay("F");

        ETimeDown = ETimeInit;
        ETimeUp = ETimeInit;
        FTimeDown = FTimeInit;
        FTimeUp = FTimeInit;
        HealthCheck = HealthTimeInit;
    }

    bool TimerCheck( ref float DownTimer, ref float UpTimer, float initial )
    {
        if( DownTimer > 0 )
        {
            DownTimer -= Time.deltaTime;
            if( DownTimer < 0 )
            {
                UpTimer = initial;
                return true;
            }
        }
        else
        {
            UpTimer -= Time.deltaTime;
            if (UpTimer < 0)
            {
                DownTimer = initial;
                return true;
            }
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKey(KeyCode.E) )
        {
            EKey.KeyState = "Down";
        }
        else
        {
            EKey.KeyState = "Up";
        }

        if (Input.GetKey(KeyCode.F))
        {
            FKey.KeyState = "Down";
        }
        else
        {
            FKey.KeyState = "Up";
        }

        if( TimerCheck( ref ETimeDown, ref ETimeUp, ETimeInit ) )
        {
            if( ETimeDown < 0 )
            {
                EKey.TargetState = "Up";
            }
            else
            {
                EKey.TargetState = "Down";
            }
        }

        if (TimerCheck(ref FTimeDown, ref FTimeUp, FTimeInit))
        {
            if (FTimeDown < 0)
            {
                FKey.TargetState = "Up";
            }
            else
            {
                FKey.TargetState = "Down";
            }
        }

        HealthCheck -= Time.deltaTime;
        if( HealthCheck < 0 )
        {
            if( EKey.KeyState != EKey.TargetState )
            {
                EKey.FillAmount -= HealthFillDown;
            }
            else
            {
                EKey.FillAmount += HealthFillUp;
            }

            if (FKey.KeyState != FKey.TargetState)
            {
                FKey.FillAmount -= HealthFillDown;
            }
            else
            {
                FKey.FillAmount += HealthFillUp;
            }
            HealthCheck = HealthTimeInit;
        }

    }
}
