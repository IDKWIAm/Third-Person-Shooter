using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public RectTransform valueRectTransform;

    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    public float lerpSpeed = 1f;

    private float _lerpValue;
    private float _maxHealth;
    private bool _dead;
    private bool _lerpIncrease;
    private bool _lerpDecrease;

    private Animator _childAnim;

    private void Start()
    {
        _childAnim = transform.GetChild(0).GetComponent<Animator>();
        _maxHealth = health;
        DrawHealthBar(0f);
    }

    //private void Update()
    //{
    //    if (_lerpIncrease)
    //    {
    //        _lerpValue += lerpSpeed * Time.deltaTime;
    //        
    //        if (_lerpValue >= 1)
   //         {
   //             _lerpIncrease = false;
   //         }
   //      }

   //      if (_lerpDecrease)
   //      {
   //          _lerpValue -= lerpSpeed * Time.deltaTime;

   //         if (_lerpValue <= 0)
   //         {
   //             _lerpDecrease = false;
   //         }
   //     }
   // }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && !_dead)
        {
            PlayerIsDead();
        }
        _lerpDecrease = true;
        DrawHealthBar(damage);
    }

    public void AddHealth(float healAmount)
    {
        health += healAmount;
        health = Mathf.Clamp(health, 0, _maxHealth);
        _lerpIncrease = true;
        DrawHealthBar(healAmount);
    }

    private void DrawHealthBar(float changeValue)
    {
        //if (_lerpIncrease)
        //{
        //    _lerpValue = 0f;
        //    valueRectTransform.anchorMax = Vector2.Lerp(new Vector2(health - changeValue / _maxHealth, 1), new Vector2(health / _maxHealth, 1), _lerpValue);
        //}

        //if (_lerpDecrease)
        //{
        //    _lerpValue = 1f;
        //    valueRectTransform.anchorMax = Vector2.Lerp(new Vector2(health + changeValue / _maxHealth, 1), new Vector2(health / _maxHealth, 1), _lerpValue);
        //    _lerpDecrease = false;
        //}
        valueRectTransform.anchorMax = new Vector2(health / _maxHealth, 1);
    }

    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);

        _childAnim.SetBool("Dead", true);
        _dead = true;

        GetComponent<PlayerController>().enabled = false;
        GetComponent<BulletCaster>().enabled = false;
        GetComponent<GrenadeCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }
}
