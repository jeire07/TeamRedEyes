using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine StateMachine;
    protected readonly PlayerGroundData groundData;

    public PlayerBaseState(PlayerStateMachine playerstateMachine)
    {
        StateMachine = playerstateMachine;
        groundData = StateMachine.player.Data.GroundData;
    }

    public void Enter()
    {
        AddInputActionsCallbacks();
    }

    public void Exit()
    {
        RemoveInputActionsCallbacks();
    }

    public void HandleInput()
    {
        ReadMovementInput();
    }

   

    public void PhysicsUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }

    protected virtual void AddInputActionsCallbacks()
    {

    }
    public virtual void RemoveInputActionsCallbacks()
    {

    }

    private void ReadMovementInput()
    {
        StateMachine.MovementInput = StateMachine.player.Input.playerActions.move.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();

        Rotate(movementDirection);

        Move(movementDirection);
    }

    private Vector3 GetMovementdirction()
    {
        Vector3 forward = StateMachine.MainCameraTransform.forward;
        Vector3 right = StateMachine.MainCameraTransform.rigth;

        forward.y = 0;
        rigth.y = 0;

        forward.Normalize();
        right.Normalize();

        return forward* StateMachine.MovementInput.y + right* StateMachine.MovementInput.x;
    }
}
