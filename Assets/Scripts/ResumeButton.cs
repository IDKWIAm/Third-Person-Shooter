using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public GameObject player;
    public void ResumeGame()
    {
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<CameraRotation>().enabled = true;
        player.GetComponent<BulletCaster>().enabled = true;
        player.GetComponent<GrenadeCaster>().enabled = true;
        transform.parent.GetComponent<Animator>().SetTrigger("WindowDisappear");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
