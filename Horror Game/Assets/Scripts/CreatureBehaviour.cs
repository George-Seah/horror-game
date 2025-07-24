using UnityEngine;
using UnityEngine.AI;

public class CreatureBehaviour : MonoBehaviour
{
    NavMeshAgent navMeshAgent;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player)
        {
            navMeshAgent.SetDestination(player.transform.position);
        }
    }
}
