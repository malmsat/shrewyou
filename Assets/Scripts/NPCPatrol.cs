using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol : MonoBehaviour
{
    public Transform[] patrolPoints; // Assign in Inspector
    private int currentPointIndex = 0;
    private NavMeshAgent agent;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            NextPatrolPoint();
        }
            float move = Input.GetAxisRaw("Horizontal");
        if (move != 0)
            spriteRenderer.flipX = (move < 0);
    }

    void NextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        agent.SetDestination(patrolPoints[currentPointIndex].position);
    }


}

