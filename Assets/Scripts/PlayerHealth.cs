using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public RectTransform valueRectTransform;

    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    private float _maxHealth;
    private bool _dead;
    private Animator _childAnim;

    private void Start()
    {
        _childAnim = transform.GetChild(0).GetComponent<Animator>();
        _maxHealth = health;
        DrawHealthBar();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && !_dead)
        {
            PlayerIsDead();
        }

        DrawHealthBar();
    }

    public void AddHealth(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, _maxHealth);
        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        valueRectTransform.localScale = new Vector2(health / _maxHealth, 1);
    }

    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);

        _childAnim.SetTrigger("Dead");
        _dead = true;

        GetComponent<PlayerController>().enabled = false;
        GetComponent<BulletCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }
}
