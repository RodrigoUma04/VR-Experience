using UnityEngine;
using UnityEngine.AI;

public class TankAI : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (target != null)
            agent.SetDestination(target.position);
    }

    void Update()
    {
        if (target != null)
            agent.SetDestination(target.position);
    }
}