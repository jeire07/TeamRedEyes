using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

 public class PlayerBaseState : IState
{
    protected PlayerStateMachine StateMachine;
    protected readonly PlayerGroundData groundData;

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        StateMachine = playerStateMachine;
        groundData = StateMachine.Player.Data.GroundData;
    }

    public virtual void Enter()
    {
        AddInputActionsCallbacks();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallbacks();
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

   

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Update()
    {
        Move();
    }

    protected virtual void AddInputActionsCallbacks()
    {
        PlayerInput input = StateMachine.Player.Input;
        input.PlayerActions.Movement.canceled += OnMovementCanceled;
        input.PlayerActions.Run.started += OnRunstarted;
    }

    protected virtual void RemoveInputActionsCallbacks()
    {
        PlayerInput input = StateMachine.Player.Input;
        input.PlayerActions.Movement.canceled -= OnMovementCanceled;
        input.PlayerActions.Run.started -= OnRunstarted;
    }

    protected virtual void OnRunstarted(InputAction.CallbackContext context)
    {
    
    }

    protected virtual void OnMovementCanceled(InputAction.CallbackContext context)
    {
  
    }

    private void ReadMovementInput()
    {
        StateMachine.MovementInput = StateMachine.Player.Input.PlayerActions.Movement.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementdirction();

        Rotate(movementDirection);  

        Move(movementDirection);
    }

    private Vector3 GetMovementdirction()
    {
        Vector3 forward = StateMachine.MainCameraTransform.forward;
        Vector3 right = StateMachine.MainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        return forward* StateMachine.MovementInput.y + right* StateMachine.MovementInput.x;
    }
    private void Move(Vector3 movementDirection)
    {
        float movementSpeed = GetMovementSpeed();
        StateMachine.Player.Controller.Move((movementDirection * movementSpeed) * Time.deltaTime);
    }

    private void Rotate(Vector3 movementDirection)
    {
        if(movementDirection != Vector3.zero)
        {
            Transform playerTransform = StateMachine.Player.transform;
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, StateMachine.RotationDamping * Time.deltaTime);
        }
    }
    private float GetMovementSpeed()
    {
        float movementSpeed = StateMachine.MovementSpeed * StateMachine.MovementspeedModifier;
        return movementSpeed;
    }

    protected void StartAnimation(int animationHash)
    {
        StateMachine.Player.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        StateMachine.Player.Animator.SetBool(animationHash, false);
    }
}
