using UnityEngine;

public class Quit : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
