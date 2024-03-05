using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionSpeed = 1f;
    public float maxSize = 5f;
    public float damage = 50f;

    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        transform.localScale += Vector3.one * explosionSpeed * Time.deltaTime;

        if (transform.localScale.x > maxSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DealDamage(damage);
        }

         var enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }
}
