using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EscapeBehav : MonoBehaviour
{
    public InputAction exitInput;
    float exitInputReading;

    private void OnEnable()
    {
        exitInput.Enable();
    }

    private void OnDisable()
    {
        exitInput.Disable();
    }

    void FixedUpdate()
    {
        exitInputReading = exitInput.ReadValue<float>();
        if (exitInputReading > 0)
        {
            Exit();
        }
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
