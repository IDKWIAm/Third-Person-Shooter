using TMPro;
using UnityEngine;

public class SetTextScript : MonoBehaviour
{
    public Transform checkpoint;
    public GameData gameData;
    public RectTransform taskDescriptionImage;
    public float height;
    public TextMeshProUGUI taskDescriptionText;
    public string message;
    public float delay = 1.5f;

    public void UpdateText()
    {
        Invoke("DelayedUpdateText", delay);
    }

    private void DelayedUpdateText()
    {
        taskDescriptionText.text = message;
        taskDescriptionImage.sizeDelta = new Vector2(taskDescriptionImage.rect.width, height);

        gameData.SaveData(checkpoint);
    }
}
