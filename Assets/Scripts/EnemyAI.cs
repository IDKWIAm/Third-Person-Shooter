using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public Transform bulletSource;
    public GameObject bulletPrefab;

    public float viewAngle = 360;
    public float rotationSpeed = 5f;
    public float FireRate = 0.5f;
    public float waitingTime = 0f;
    public float attackRange = 20f;
    public float walkSpeed = 1.5f;
    public float runSpeed = 3.5f;
    public bool isGuard;
    public bool isPatrolman = true;

    private int point;
    private bool _isPlayerNoticed;
    private bool _isWaiting;
    private float _timer;

    private PlayerHealth _playerHealth;
    private NavMeshAgent _navMeshAgent;
    private Animator _childAnim;
    private GameObject _player;

    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();        
    }

    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        AttackUpdate();
        SetAnimSpeedUpdate();
        PatrolUpdate();
    }

    private void InitComponentLinks()
    {
        _playerHealth = player.gameObject.GetComponent<PlayerHealth>();
        _childAnim = transform.GetChild(0).GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void PickNewPatrolPoint()
    {
        point = Random.Range(0, patrolPoints.Count);
        _navMeshAgent.speed = walkSpeed;
        Invoke("DisableWaiting", 2);
    }

    private void NoticePlayerUpdate()
    {

        _isPlayerNoticed = false;

        if (_playerHealth.health <= 0) return;

        var direction = player.transform.position - transform.position;
        
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up * 1.5f, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _player = hit.collider.gameObject;
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed && !isGuard)
        {
            _navMeshAgent.destination = player.transform.position;
        }
        else
        {
            _navMeshAgent.destination = patrolPoints[point].position;
        }
    }

    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            if (!_isWaiting)
            {
                _navMeshAgent.speed = 0f;
                _isWaiting = true;
                if (isPatrolman)
                {
                    Invoke("PickNewPatrolPoint", waitingTime);
                }
            }
        }
    }

    private void AttackUpdate()
    {
        _childAnim?.SetBool("Aiming", false);

        if (_isPlayerNoticed)
        {
            var heading = _player.transform.position - gameObject.transform.position;

            var distance = heading.magnitude;

            if (distance <= attackRange)
            {
                Vector3 direction = (player.transform.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

                _childAnim?.SetBool("Aiming", true);
                _navMeshAgent.speed = 0f;

                _timer -= Time.deltaTime;
                if (_timer <= 0)
                {
                    Fire();
                    _timer = FireRate;
                }
            }
            else if (!isGuard)
            {
                _navMeshAgent.speed = runSpeed;
            }
        }
        else
        {
            if (!_isWaiting)
            {
                _navMeshAgent.speed = walkSpeed;
            }
        }
    }

    private void SetAnimSpeedUpdate()
    {
        _childAnim?.SetFloat("Speed", 0);

        if (_navMeshAgent.speed > 2)
        {
            _childAnim?.SetFloat("Speed", 1);
        }
        else if (_navMeshAgent.speed <= 2 && _navMeshAgent.speed > 0)
        {
            _childAnim?.SetFloat("Speed", 0.5f);
        }
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, bulletSource.position, bulletSource.rotation);
        _childAnim?.SetTrigger("Attack");
    }

    private void DisableWaiting()
    {
        _isWaiting = false;
    }
}
