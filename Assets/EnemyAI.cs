using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    private NavMeshAgent agent;
    private int currentPoint = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (patrolPoints.Length > 0)
        {
            agent.destination = patrolPoints[0].position;
        }
    }

    void Update()
    {
        if (patrolPoints.Length == 0 || agent.pathPending)
            return;

        if (agent.remainingDistance < 0.5f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
            agent.destination = patrolPoints[currentPoint].position;
        }
    }
}
