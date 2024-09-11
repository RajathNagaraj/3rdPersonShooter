using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private InputActions inputActions;
    private CinemachineComposer composer;
    [SerializeField]
    private float turnDampener = 0.01f;

    private void Start()
    {
        inputActions = GameManager.Instance.inputActions;
        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
    }

    
   private void Update()
    {
        var lookVector = inputActions.OnFoot.Look.ReadValue<Vector2>();
        composer.m_TrackedObjectOffset.y += (lookVector.y * turnDampener);
        composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, -10, 10);
    }
}
