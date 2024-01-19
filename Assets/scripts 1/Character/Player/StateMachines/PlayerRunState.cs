using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerGroundState
{
    public PlayerRunState(PlayerStateMachine playerstateMachine) : base(playerstateMachine)
    {
    }

    public override void Enter()
    {
        StateMachine.MovementspeedModifier = groundData.RunSpeedModifier;
        base.Enter();
        StartAnimation(StateMachine.Player.AnimationData.RunParameterHash);
    }
    public override void Exit() 
    { 
        base.Exit();
        StopAnimation(StateMachine.Player.AnimationData.RunParameterHash);
    }
}
