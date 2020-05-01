using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class CommandScript : MonoBehaviour
{
    [SerializeField]
    bool isCommanding = false;

    PlayerControls controls;

    void OnEnable()
    {
        controls = new PlayerControls();
        controls.Priest.Command.performed += CommandPressed;
        controls.Priest.Confirm.performed += ConfirmPressed;
        controls.Priest.Cancel.performed += CancelPressed;
        controls.Priest.Command.Enable();
        controls.Priest.Confirm.Enable();
        controls.Priest.Cancel.Enable();
    }

    private void CancelPressed(CallbackContext obj)
    {
        if (isCommanding)
        {
            isCommanding = false;
        }
    }

    private void ConfirmPressed(CallbackContext obj)
    {
        if(isCommanding)
        {
            SendCommand(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        }
    }

    void CommandPressed(CallbackContext callback)
    {
        isCommanding = !isCommanding;
    }

    private void SendCommand(Vector3 mousePosition)
    {
        foreach(GoodGuyAI goodGuy in FindObjectsOfType<GoodGuyAI>())
        {
            goodGuy.Command(mousePosition);
        }

    }
}
