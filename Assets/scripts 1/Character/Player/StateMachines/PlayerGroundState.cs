using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundState : PlayerBaseState
{
    public PlayerGroundState(PlayerStateMachine playerstateMachine) : base(playerstateMachine)
    {
     
    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(StateMachine.Player.AnimationData.GroundParameterHash);
    }
    public override void Exit() 
    { 
        base.Exit();
        StopAnimation(StateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if(StateMachine.IsAttacking)
        {
            OnAttack();
            return;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if(!StateMachine.Player.Controller.isGrounded && StateMachine.Player.Controller.velocity.y < Physics.gravity.y * Time.fixedDeltaTime)
        {
            StateMachine.ChangeState(StateMachine.FallState);
            return;
        
        }
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        if(StateMachine.MovementInput == Vector2.zero)
        {
            return;
        }

        StateMachine.ChangeState(StateMachine.IdleState);
        base.OnMovementCanceled(context);
    }

    protected override void OnJumpStarted(InputAction.CallbackContext context)
    {
        StateMachine.ChangeState(StateMachine.JumpState);
    }

    protected virtual void OnMove()
    {
        StateMachine.ChangeState(StateMachine.WalkState);
    }

    protected override void OnRollStarted(InputAction.CallbackContext context)
    {
        StateMachine.ChangeState(StateMachine.RollState);
    }

    protected override void OnSitStated(InputAction.CallbackContext context)
    {
        StateMachine.ChangeState(StateMachine.SitState);
    }

    protected virtual void OnAttack()
    {
        StateMachine.ChangeState(StateMachine.ComboAttackState);
    }

}
