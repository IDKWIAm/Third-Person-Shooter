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
        DamageEnemy(collision);
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

    private void DamageEnemy(Collision collision)
    {
        var enemyHeathComponent = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemyHeathComponent != null)
        {
            enemyHeathComponent.DealDamage(damage);
        }
    }
}