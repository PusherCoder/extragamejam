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
        EKey = KeyDisplayContainer.CreateKeyDisplay("E");
        FKey = KeyDisplayContainer.CreateKeyDisplay("F");

        StartCoroutine(EKeyTimer_Co());
        StartCoroutine(FKeyTimer_Co());

        ETimeDown = ETimeInit;
        ETimeUp = ETimeInit;
        FTimeDown = FTimeInit;
        FTimeUp = FTimeInit;
        HealthCheck = HealthTimeInit;
    }

    private bool eShouldBeDown;
    private bool fShouldBeDown;

    private IEnumerator EKeyTimer_Co()
    {
        eShouldBeDown = false;
        while (true)
        {
            yield return new WaitForSeconds(ETimeInit);
            eShouldBeDown = !eShouldBeDown;
        }
    }

    private IEnumerator FKeyTimer_Co()
    {
        fShouldBeDown = false;
        while (true)
        {
            yield return new WaitForSeconds(FTimeInit);
            fShouldBeDown = !fShouldBeDown;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if( Input.GetKey(KeyCode.E) ) EKey.KeyState = "Down";
        else EKey.KeyState = "Up";

        if (Input.GetKey(KeyCode.F))  FKey.KeyState = "Down";
        else FKey.KeyState = "Up";

        if(eShouldBeDown) EKey.TargetState = "Down";
        else EKey.TargetState = "Up";

        if ( fShouldBeDown )  FKey.TargetState = "Down";
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


        /*HealthCheck -= Time.deltaTime;
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
        }*/
    }
}
