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

    private bool _notTriggered = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && _notTriggered)
        {
            taskManagerAnim.SetTrigger("Completed");
            Invoke("SetText", 1.5f);

            button.SetActive(true);
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
