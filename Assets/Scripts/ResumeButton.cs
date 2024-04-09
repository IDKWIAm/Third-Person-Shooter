using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public GameObject player;
    public void ResumeGame()
    {
        transform.parent.GetComponent<Animator>().SetTrigger("WindowDisappear");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
