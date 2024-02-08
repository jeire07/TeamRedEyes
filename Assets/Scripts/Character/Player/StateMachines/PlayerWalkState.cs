using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : PlayerGroundState
{
    public PlayerWalkState(PlayerStateMachine playerstateMachine) : base(playerstateMachine)
    {
    }

    public override void Enter()
    {
        StateMachine.MovementspeedModifier = groundData.WalkSpeedModifier;
        base.Enter();
        StartAnimation(StateMachine.Player.AnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(StateMachine.Player.AnimationData.WalkParameterHash);
    }

    protected override void OnRunstarted(InputAction.CallbackContext context)
    {
        base.OnRunstarted(context);
        StateMachine.ChangeState(StateMachine.RunState);
    }

    protected override void OnSitStated(InputAction.CallbackContext context)
    {
        base.OnSitStated(context);
        StateMachine.ChangeState(StateMachine.SitState);
    }
}
