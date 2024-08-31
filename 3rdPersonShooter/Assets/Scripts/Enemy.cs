using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AggroDetection aggroDetection;
    private Health healthTarget;

    private void Awake() 
    {
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += PlayerDetected;
    }

    private void PlayerDetected(Transform transform)
    {
       Health health = transform.GetComponent<Health>();
       if(health != null)
       {
            healthTarget = health;
       }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
