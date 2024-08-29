using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AggroDetection : MonoBehaviour
{
    
    public event Action<Transform> OnAggro = delegate{};
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerMovement>();

        if(player != null)
        {
            Debug.Log("Enemy AGGrod");
            OnAggro(player.transform);
        }
    }
}
