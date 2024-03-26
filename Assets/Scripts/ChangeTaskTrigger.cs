using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTaskTrigger : MonoBehaviour
{
    public RectTransform taskDescriptionImage;
    public float height;
    public TextMeshProUGUI taskDescriptionText;
    public string message;
    public GameObject button;
    public Animator taskManagerAnim;
    public GameObject gate;

    public GameObject[] activateEnemies;

    private bool _notTriggered = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && _notTriggered)
        {
            if (gate != null)
            {
                gate.transform.localPosition -= new Vector3(22, 0, 0);
            }

            taskManagerAnim.SetTrigger("Completed");
            Invoke("SetText", 1.5f);

            button.SetActive(true);

            for (int i = 0; i < activateEnemies.Length; i++)
            {
                activateEnemies[i].SetActive(true);
            }

            _notTriggered = false;
        }
    }

    private void SetText()
    {
        taskDescriptionImage.sizeDelta = new Vector2(taskDescriptionImage.rect.width, height);
        taskDescriptionText.text = message;
        Destroy(gameObject);
    }
}
