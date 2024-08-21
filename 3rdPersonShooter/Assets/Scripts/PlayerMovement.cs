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
    private float turnSpeed = 5f;

    void Awake()
    {      
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        inputActions = GameManager.Instance.inputActions;
        moveSpeed = 400f;
    }

    // Update is called once per frame
    void Update()
    {
        var movementVector2D =  inputActions.OnFoot.Move.ReadValue<Vector2>();
        float animSpeed = movementVector2D.magnitude;
        animator.SetFloat("Speed",animSpeed);
        Vector3 movement = new Vector3(movementVector2D.x, 0, movementVector2D.y);
        characterController.SimpleMove(movement * moveSpeed * Time.deltaTime);


        if(movement.magnitude > 0)
        {
            Quaternion newDirection = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
        }
       
    }
}
