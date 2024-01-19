using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(PlayerStateMachine playerstateMachine) : base(playerstateMachine)
    {
    }

    public override void Enter()
    {
        StateMachine.MovementspeedModifier = 0f;
        base.Enter();
        StartAnimation(StateMachine.Player.AnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(StateMachine.Player.AnimationData.IdleParameterHash);
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void PhysicsUpdate()
    {

    }

    public override void Update()
    {
        if(StateMachine.MovementInput != Vector2.zero)
        {
            OnMove();
            return;
        }
       base.Update();
    }
}
