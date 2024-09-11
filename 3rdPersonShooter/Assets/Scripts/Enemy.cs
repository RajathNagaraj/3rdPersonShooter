using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AggroDetection aggroDetection;
    private Health healthTarget;
    private float attackTimer;
    [SerializeField]
    private float attackRefreshRate = 1.5f;

    private void Awake() 
    {
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += PlayerDetected;
    }

    private void PlayerDetected(Transform player)
    {
       Health health = player.GetComponent<Health>();
       if(health != null)
       {
            healthTarget = health;
       }
    }

    

    // Update is called once per frame
    void Update()
    {
        if(healthTarget != null)
        {
            attackTimer += Time.deltaTime;
            if(CanAttack())
                Attack();
        }
    }

    private bool CanAttack()
    {
        return attackTimer >= attackRefreshRate;
    }

    private void Attack()
    {
        attackTimer = 0;
        healthTarget.TakeDamage(1);
    }
}
