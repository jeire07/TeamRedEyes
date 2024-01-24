using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSitState : PlayerGroundState
{
    public PlayerSitState(PlayerStateMachine playerstateMachine) : base(playerstateMachine)
    {
    }
    public override void Enter()
    {
        StateMachine.MovementspeedModifier = groundData.SitSpeedModifier;
        base.Enter();
        StartAnimation(StateMachine.Player.AnimationData.SitParameterHash);
        StateMachine.Player.Input.PlayerActions.Sit.canceled += OnSitCanceled;
    }
    public override void Exit() 
    { 
        base.Exit();
        StopAnimation(StateMachine.Player.AnimationData.SitParameterHash);
        StateMachine.Player.Input.PlayerActions.Sit.canceled -= OnSitCanceled;
    }

    private void OnSitCanceled(InputAction.CallbackContext context)
    {
        StateMachine.ChangeState(StateMachine.WalkState);
    }

}
