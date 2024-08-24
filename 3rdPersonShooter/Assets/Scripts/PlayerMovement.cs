using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputActions inputActions;
    private CharacterController characterController;
    [SerializeField]
    private float moveSpeed;
    private Animator animator;
    [SerializeField]
    private float turnSpeed = 150f;
    private Vector3 movement;
    private Quaternion rotation;

    void Awake()
    {      
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        inputActions = GameManager.Instance.inputActions;
        moveSpeed = 1400f;
        // rotation = Quaternion.LookRotation(transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        var movementVector2D =  inputActions.OnFoot.Move.ReadValue<Vector2>();
        var lookVector2D = inputActions.OnFoot.Look.ReadValue<Vector2>();
        Move(movementVector2D, lookVector2D);
        Animate(movementVector2D.y);
         
    }

    private void Animate(float animSpeed)
    {
        animator.SetFloat("Speed",animSpeed);    
    }

    private void Move(Vector2 movementVector, Vector2 lookVector)
    {

        movement = new Vector3(movementVector.x, 0, movementVector.y); 
       
         if(lookVector.magnitude != 0)
        {
           transform.Rotate(Vector3.up,lookVector.x * turnSpeed * Time.deltaTime);            
           rotation = Quaternion.LookRotation(transform.forward);          
           /* Debug.Log("Transform's rotation" + transform.rotation);
           Debug.Log("Angle rotation" + rotation);  */                                              
        }


        if(movementVector.magnitude != 0)
        {  
            movement = rotation * movement;        
            characterController.SimpleMove(movement * moveSpeed * Time.deltaTime);                                            
        }   

        
          
    }
}
