using UnityEngine;

public class PressedButtonScript : MonoBehaviour
{
    public GameObject[] screnes;
    public GameObject[] enemiesToActivate;
    void Start()
    {
        if (PlayerPrefs.GetString(gameObject.name) == "Pressed")
        {
            ActivateEnemies();
            DisableScrenes();
            gameObject.SetActive(false);
        }
    }

    public void ActivateEnemies()
    {
        for (int i = 0; i < enemiesToActivate.Length; i++)
        {
            if (enemiesToActivate[i] != null)
            {
                enemiesToActivate[i].SetActive(true);
            }
        }
    }

    public void DisableScrenes()
    {
        for (int i = 0; i < screnes.Length; i++)
        {
            if (screnes[i] != null)
            {
                screnes[i].SetActive(false);
            }
        }
    }
}
