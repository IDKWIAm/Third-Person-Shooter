using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToAnotherScene : MonoBehaviour
{
    public void MoveToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void MoveToGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void MoveToEnd()
    {
        SceneManager.LoadScene("End");
    }

    public void Exit()
    {
        Application.Quit();
    }
}