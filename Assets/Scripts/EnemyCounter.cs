using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public GameObject interactiveButton;

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
        if (counter >= enemiesAmount)
        {
            interactiveButton.SetActive(true);
        }
    }
}
