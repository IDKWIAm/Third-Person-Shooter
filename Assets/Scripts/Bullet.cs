using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float damage = 10;

    private void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }

    private void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) return;

        Damage(collision);
        DestroyBullet();
    }

    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void Damage(Collision collision)
    {
        var enemyHeathComponent = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemyHeathComponent != null)
        {
            enemyHeathComponent.DealDamage(damage);
        }

        var playerHeathComponent = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHeathComponent != null)
        {
            playerHeathComponent.DealDamage(damage);
        }
    }
}