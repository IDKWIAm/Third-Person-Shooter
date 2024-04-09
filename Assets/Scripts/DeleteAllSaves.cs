using UnityEngine;

public class DeleteAllSaves : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
        PlayerPrefs.DeleteAll();
    }
}
