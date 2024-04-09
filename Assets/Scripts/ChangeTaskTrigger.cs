using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTaskTrigger : MonoBehaviour
{
    public Transform spawnPointPos;

    public RectTransform taskDescriptionImage;
    public float height;
    public TextMeshProUGUI taskDescriptionText;
    public string message;
    public GameObject button;
    public Animator taskManagerAnim;
    public GameObject gate;

    public GameData gameData;

    public GameObject[] activateEnemies;

    private bool _notTriggered = true;
    private InteractiveButton _buttonScript;
    private GameObject canvas;

    private void Start()
    {
        if (button != null)
        {
            _buttonScript = button.GetComponent<InteractiveButton>();
            canvas = button.transform.GetChild(0).gameObject;
        }

        if (PlayerPrefs.HasKey(gameObject.name))
        {
            OpenGate();
            ActivateEnemies();

            if (button != null && PlayerPrefs.GetString(button.name) == "Activated")
            {
                ActivateButton();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && _notTriggered && !PlayerPrefs.HasKey(gameObject.name))
        {
            OpenGate();

            taskManagerAnim.SetTrigger("Completed");
            Invoke("SetText", 1.5f);

            if (_buttonScript != null)
            {
                ActivateButton();
                PlayerPrefs.SetString(button.name, "Activated");
            }

            ActivateEnemies();

            _notTriggered = false;

            PlayerPrefs.SetString(gameObject.name, "Destroyed");
        }
    }

    private void SetText()
    {
        taskDescriptionImage.sizeDelta = new Vector2(taskDescriptionImage.rect.width, height);
        taskDescriptionText.text = message;

        gameData.SaveData(spawnPointPos);

        Destroy(gameObject);
    }

    private void OpenGate()
    {
        if (gate != null)
        {
            gate.transform.localPosition -= new Vector3(22, 0, 0);
        }
    }

    private void ActivateEnemies()
    {
        for (int i = 0; i < activateEnemies.Length; i++)
        {
            if (activateEnemies[i] != null)
            {
                activateEnemies[i].SetActive(true);
            }
        }
    }

    private void ActivateButton()
    {
        _buttonScript.enabled = true;
        canvas.SetActive(true);
    }
}
