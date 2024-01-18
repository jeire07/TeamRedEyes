using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
