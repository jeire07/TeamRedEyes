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
        RotateTowardsMouseCursor();
    }

    private void RotateTowardsMouseCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetDirection = hit.point - StateMachine.Player.transform.position;
            targetDirection.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            StateMachine.Player.transform.rotation = Quaternion.Slerp(StateMachine.Player.transform.rotation, targetRotation, StateMachine.RotationDamping * Time.deltaTime);
        }
    }

    protected virtual void AddInputActionsCallbacks()
    {
        PlayerInput input = StateMachine.Player.Input;
        input.PlayerActions.Movement.canceled += OnMovementCanceled;
        input.PlayerActions.Run.started += OnRunstarted;
        input.PlayerActions.Jump.started += OnJumpStarted;
        input.PlayerActions.Roll.started += OnRollStarted;
        input.PlayerActions.Sit.started += OnSitStated;
        input.PlayerActions.Attack.performed += OnAttackPerformed;
        input.PlayerActions.Attack.canceled += OnAttackCanceled;
    }

    protected virtual void RemoveInputActionsCallbacks()
    {
        PlayerInput input = StateMachine.Player.Input;
        input.PlayerActions.Movement.canceled -= OnMovementCanceled;
        input.PlayerActions.Run.started -= OnRunstarted;
        input.PlayerActions.Jump.started -= OnJumpStarted;
        input.PlayerActions.Roll.started -= OnRollStarted;
        input.PlayerActions.Sit.started -= OnSitStated;
        input.PlayerActions.Attack.performed -= OnAttackPerformed;
        input.PlayerActions.Attack.canceled -= OnAttackCanceled;
    }

    protected virtual void OnRunstarted(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnMovementCanceled(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnJumpStarted(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnSitStated(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnRollStarted(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnAttackPerformed(InputAction.CallbackContext context)
    {
        if (!StateMachine.IsAttacking)
        {
            StateMachine.ChangeState(StateMachine.ComboAttackState);
        }
    }

    protected virtual void OnAttackCanceled(InputAction.CallbackContext context)
    {
        if (StateMachine.IsAttacking)
        {
            StateMachine.IsAttacking = false;
            StateMachine.ChangeState(StateMachine.IdleState);
        }
    }

    private void ReadMovementInput()
    {
        StateMachine.MovementInput = StateMachine.Player.Input.PlayerActions.Movement.ReadValue<Vector2>();
    }

    private void Move()
    {
        if (StateMachine.IsRolling)
        {
            // 롤 중일 때는 기본 이동을 수행하지 않음
            return;
        }

        Vector3 movementDirection = GetMovementDirection();

        Rotate(movementDirection);
        ApplyMovement(movementDirection);
    }

    private Vector3 GetMovementDirection()
    {
        Vector3 forward = StateMachine.MainCameraTransform.forward;
        Vector3 right = StateMachine.MainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        return forward * StateMachine.MovementInput.y + right * StateMachine.MovementInput.x;
    }

    private void ApplyMovement(Vector3 movementDirection)
    {
        float movementSpeed = GetMovementSpeed();
        Vector3 movement = movementDirection * movementSpeed + StateMachine.Player.ForceReceiver.Movement;
        StateMachine.Player.Controller.Move(movement * Time.deltaTime);
    }

    protected void ForceMove()
    {
        StateMachine.Player.Controller.Move(StateMachine.Player.ForceReceiver.Movement * Time.deltaTime);
    }

    private void Rotate(Vector3 movementDirection)
    {
        if (movementDirection != Vector3.zero)
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

    protected float GetNomarlizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag)) 
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }
}
