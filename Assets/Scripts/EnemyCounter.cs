using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public RectTransform taskDescriptionImage;
    public float height;
    public TextMeshProUGUI taskDescriptionText;
    public string message;
    public GameObject interactiveButton;
    public Animator taskManagerAnim;

    public bool isTutorial;
    public GameObject escapeText;
    public GameObject finishText;

    private int enemiesAmount;
    private int counter;

    public void AddCount()
    {
        counter += 1;
        CheckCount();
    }

    public void AddEnemy()
    {
        enemiesAmount += 1;
    }

    private void CheckCount()
    {
        if (counter >= enemiesAmount && !isTutorial)
        {
            interactiveButton.SetActive(true);
            taskManagerAnim.SetTrigger("Completed");
            Invoke("SetText", 1.5f);
        } else if (isTutorial)
        {
            finishText.SetActive(false);
            escapeText.SetActive(true);

        }
    }

    private void SetText()
    {
        taskDescriptionImage.sizeDelta = new Vector2(taskDescriptionImage.rect.width, height);
        taskDescriptionText.text = message;
    }
}
