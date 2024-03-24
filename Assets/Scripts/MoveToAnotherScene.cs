using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToAnotherScene : MonoBehaviour
{
    public int scene;

    public void Move()
    {
        if (scene == 1)
        {
            SceneManager.LoadScene("Main Menu");
        }
        if (scene == 2)
        {
            SceneManager.LoadScene("Tutorial");
        }
        if (scene == 3)
        {
            SceneManager.LoadScene("Prologue");
        }
        if (scene == 4)
        {
            SceneManager.LoadScene("End");
        }
        if (scene == 5)
        {
            Application.Quit();
        }
    }
}