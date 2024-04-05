using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputActions inputActions;

    void Awake()
    {
        if(Instance == null)
        {
            inputActions = new InputActions();
            Instance = this;            
        }
           
        else
            return;
    }

    void OnEnable()
    {
        inputActions.OnFoot.Enable();
    }

    void OnDisable()
    {
        inputActions.OnFoot.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
