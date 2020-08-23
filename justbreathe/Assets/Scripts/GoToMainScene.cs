using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            GameManager.Level = 1;
            SceneManager.LoadScene("GameScene");
        }
    }
}
