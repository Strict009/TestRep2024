using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;
    public bool freeRoamEnabled = false;
    public bool pursuePlayerEnabled = false;
    private NavMeshAgent navMeshAgent;
    private GameObject player;
    private Flashlight flashlight;
    private bool isFrozen = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        flashlight = FindObjectOfType<Flashlight>();

        if (freeRoamEnabled)
        {
            SetRandomDestination();
        }
        else
        {
            SetDestinationToNextPatrolPoint();
        }
    }

    void Update()
    {
        if (!isFrozen)
        {
            if (pursuePlayerEnabled && player != null)
            {
                navMeshAgent.SetDestination(player.transform.position);
            }
            else if (freeRoamEnabled)
            {
                if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
                {
                    SetRandomDestination();
                }
            }
            else
            {
                if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
                {
                    SetDestinationToNextPatrolPoint();
                }
            }
        }

        if (flashlight != null && flashlight.spotlight.enabled) 
        {
            if (flashlight.IsAimingAtEnemy(transform.position))
            {
                isFrozen = true;
                navMeshAgent.isStopped = true;
            }
            else
            {
                isFrozen = false;
                navMeshAgent.isStopped = false;
            }
        }
        else
        {
            isFrozen = false;
            navMeshAgent.isStopped = false;
        }
    }

    void SetDestinationToNextPatrolPoint()
    {
        if (patrolPoints.Length > 0)
        {
            navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
        else
        {
            Debug.LogWarning("No patrol points assigned.");
        }
    }

    void SetRandomDestination()
    {
        Vector3 randomDestination = RandomNavMeshPoint(10f);
        navMeshAgent.SetDestination(randomDestination);
    }

    Vector3 RandomNavMeshPoint(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas);
        return hit.position;
    }
}
