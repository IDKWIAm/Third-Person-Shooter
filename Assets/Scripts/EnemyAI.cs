using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle = 360;

    private NavMeshAgent _navMeshAgent;
    private int point;
    private bool _isPlayerNoticed;

    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
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
        if (_navMeshAgent.remainingDistance <= 0)
        {
            PickNewPatrolPoint();
        }
    }
}
