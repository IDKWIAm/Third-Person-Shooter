using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public RectTransform valueRectTransform;

    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    private float maxHealth;

    private void Start()
    {
        maxHealth = health;
        DrawHealthBar();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            PlayerIsDead();
        }

        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        valueRectTransform.localScale = new Vector2(health / maxHealth, 1);
    }

    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<BulletCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }
}
