using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchToAimCam : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput = null;
    [SerializeField]
    private int proirityBoostAmount = 10;

    private CinemachineVirtualCamera virtualCamera = null;
    private InputAction aimAction = null;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        aimAction = playerInput.actions["Aim"];
    }

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    void StartAim()
    {
        virtualCamera.Priority += proirityBoostAmount;
    }

    void CancelAim()
    {
        virtualCamera.Priority -= proirityBoostAmount;
    }
}
