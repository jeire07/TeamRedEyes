using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
 
    public PlayerInputaction InputActions {  get; private set; }

    public PlayerInputaction.PlayerActions playerActions { get; private set; }

    private void Awake()
    {
        InputActions = new PlayerInputaction();
        playerActions = InputActions.Player;
    }

    private void OnEnable()
    {
        InputActions.Enable();
    }

    private void OnDisable()
    {
        InputActions.Disable();
    }
}
