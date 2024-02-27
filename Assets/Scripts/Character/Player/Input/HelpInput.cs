using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HelpInput : MonoBehaviour
{
    public GameObject Help;
    public bool IsOpened = false;

    public void OnF1Key(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            IsOpened = !IsOpened;
            Help.SetActive(IsOpened);
        }
    }
}
