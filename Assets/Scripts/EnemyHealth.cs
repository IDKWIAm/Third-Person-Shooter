using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public EnemyCounter enemyCounter;
    public float addCountDelay;

    public float health = 100;

    private Animator _enemyAnimator;

    private void Start()
    {
        InitAnimator();
        AddEnemyToCounter();
    }

    private void InitAnimator()
    {
        _enemyAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void AddEnemyToCounter()
    {
        if (enemyCounter != null)
        {
            enemyCounter.AddEnemy();
        }
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

            if (enemyCounter != null)
            {
                enemyCounter.Invoke("AddCount", addCountDelay);
            }
        }
        else
        {
            _enemyAnimator?.SetTrigger("Damage");
            _enemyAnimator?.SetInteger("DamageID", Random.Range(1, 3));
        }
    }
}
