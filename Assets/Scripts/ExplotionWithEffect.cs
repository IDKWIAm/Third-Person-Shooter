using UnityEngine;

public class ExplotionWithEffect : MonoBehaviour
{
    public float damage = 50f;
    public float playerResistance = 30;
    public float delay = 1f;

    private void Start()
    {
        Invoke("ColliderEnabled", delay);
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DealDamage(damage * (1f - playerResistance / 100));
        }

        var enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }

    private void ColliderEnabled()
    {
        gameObject.GetComponent<SphereCollider>().enabled = true;
    }
}
