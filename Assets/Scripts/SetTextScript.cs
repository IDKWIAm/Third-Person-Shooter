using TMPro;
using UnityEngine;

public class SetTextScript : MonoBehaviour
{
    public RectTransform taskDescriptionImage;
    public float height;
    public TextMeshProUGUI taskDescriptionText;
    public string message;
    public float delay = 1.5f;

    public void SetText()
    {
        Invoke("DelayText", delay);
    }

    public void SetHeight()
    {
        Invoke("DelayHeight", delay);
    }

    private void DelayText()
    {
        taskDescriptionText.text = message;
    }

    private void DelayHeight()
    {
        taskDescriptionImage.sizeDelta = new Vector2(taskDescriptionImage.rect.width, height);
    }
}
