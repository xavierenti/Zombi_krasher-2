using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{

    [SerializeField] private Transform player;
    private Rigidbody2D rb;
    private NavMeshAgent navMeshAgent;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        navMeshAgent.SetDestination(player.position);
    }
}
