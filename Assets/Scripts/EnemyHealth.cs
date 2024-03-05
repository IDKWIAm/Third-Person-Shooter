using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;

    private Animator _enemyAnimator;

    private void Start()
    {
        InitAnimator();
    }

    private void InitAnimator()
    {
        _enemyAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            _enemyAnimator?.SetTrigger("Death");
            GetComponent<EnemyAI>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            _enemyAnimator?.SetTrigger("Damage");
            _enemyAnimator?.SetInteger("DamageID", Random.Range(1, 3));
        }
    }
}
