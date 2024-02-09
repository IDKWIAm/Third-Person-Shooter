using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    void Start()
    {
        
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
