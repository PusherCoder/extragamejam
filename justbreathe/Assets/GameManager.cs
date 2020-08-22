using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const float HealthFillDown = .5f;
    private const float HealthFillUp = .25f;

    [SerializeField] private KeyDisplay EKey;
    [SerializeField] private KeyDisplay FKey;

    // Start is called before the first frame update
    void Start()
    {
        EKey.SetInitalValues("E", 1.0f, 1.0f, false);
        FKey.SetInitalValues("F", 2.0f, 2.0f, false);
    }

    // Update is called once per frame
    void Update()
    {
        EKey.IsDown = Input.GetKey(KeyCode.E);
        FKey.IsDown = Input.GetKey(KeyCode.F);

        //Maybe just decrease the health a little bit every frame?
        if (EKey.IsDown != EKey.ShouldBeDown)
            EKey.FillAmount -= Time.deltaTime * HealthFillDown;
        else
            EKey.FillAmount += Time.deltaTime * HealthFillUp;

        if (FKey.IsDown != FKey.ShouldBeDown)
            FKey.FillAmount -= Time.deltaTime * HealthFillDown;
        else
            FKey.FillAmount += Time.deltaTime * HealthFillUp;
    }
}
