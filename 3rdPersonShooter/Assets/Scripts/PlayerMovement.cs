using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputActions inputActions;
    private CharacterController characterController;
    private float moveSpeed;


    void Awake()
    {      
        characterController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        inputActions = GameManager.Instance.inputActions;
        moveSpeed = 300f;
    }

    // Update is called once per frame
    void Update()
    {
        var movementVector2D =  inputActions.OnFoot.Move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(movementVector2D.x, 0, movementVector2D.y);
        characterController.SimpleMove(movement * moveSpeed * Time.deltaTime);

    }
}
