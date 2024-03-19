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
            SceneManager.LoadScene("Main Scene");
        }
        if (scene == 3)
        {
            SceneManager.LoadScene("End");
        }
        if (scene == 4)
        {
            Application.Quit();
        }
    }
}