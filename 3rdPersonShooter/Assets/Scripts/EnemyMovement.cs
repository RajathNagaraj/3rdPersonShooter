using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private AggroDetection aggroDetection;
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private void Awake() 
    {
        navMeshAgent  = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
        
    }

    private void AggroDetection_OnAggro(Transform target)
    {
         navMeshAgent.SetDestination(target.position);
    }

    private void Update() 
    {
        float speed = navMeshAgent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }
}
