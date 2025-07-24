using UnityEngine;
using UnityEngine.AI;

public class CreatureBehaviour : MonoBehaviour
{
    NavMeshAgent navMeshAgent;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void HandleCollision(Collider other)
    {
        //GameObject player = GameObject.FindWithTag("Player");

        if (other.gameObject.tag == "Player")
        {
            navMeshAgent?.SetDestination(other.transform.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        HandleCollision(other);
    }

    void OnTriggerStay(Collider other)
    {
        HandleCollision(other);
    }
}
