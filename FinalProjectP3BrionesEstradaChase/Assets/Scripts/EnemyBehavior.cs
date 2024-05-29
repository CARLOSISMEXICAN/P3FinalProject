using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
   public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsground, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timebetweenAttacks;
    bool alraedyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake() 
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        if (!playerInSightRange && !playerInAttackRange) Patroling();
    }    

    private void Upadte()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
    }

}
