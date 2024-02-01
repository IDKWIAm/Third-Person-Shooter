using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;

    private NavMeshAgent _navMeshAgent;
    private int point;

    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    void Update()
    {
        PatrolUpdate();
    }

    private void PickNewPatrolPoint()
    {
        point = Random.Range(0, patrolPoints.Count);
    }

    private void PatrolUpdate()
    {
        if (transform.position.x == patrolPoints[point].position.x && transform.position.z == patrolPoints[point].position.z)
        {
            PickNewPatrolPoint();
        }
        _navMeshAgent.destination = patrolPoints[point].position;
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
}
