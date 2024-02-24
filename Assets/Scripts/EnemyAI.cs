using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle = 360;
    public float damage = 30;

    private PlayerHealth _playerHealth;
    private NavMeshAgent _navMeshAgent;
    private int point;
    private bool _isPlayerNoticed;

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
        PatrolUpdate();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void PickNewPatrolPoint()
    {
        point = Random.Range(0, patrolPoints.Count);
    }

    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;

        _isPlayerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
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
        if (_isPlayerNoticed)
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
            PickNewPatrolPoint();
        }
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            var heading = _player.transform.position - gameObject.transform.position;

            var distance = heading.magnitude;

            if (distance <= _navMeshAgent.stoppingDistance)
            {
                _playerHealth.DealDamage(damage * Time.deltaTime);
            }
        }
    }
}
