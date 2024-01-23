using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollState : PlayerGroundState
{
    private float rollDuration = 0.5f; // 롤 동작의 지속 시간
    private float rollStartTime;
    private float rollDistance = 2f; // 롤 동작으로 이동할 거리

    public PlayerRollState(PlayerStateMachine playerstateMachine) : base(playerstateMachine)
    {
    }

    public override void Enter()
    {
        rollStartTime = Time.time;
        StateMachine.MovementspeedModifier = groundData.RollSpeedModifer;

        base.Enter();
        StartAnimation(StateMachine.Player.AnimationData.RollParameretHash);
        StateMachine.IsRolling = true;
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(StateMachine.Player.AnimationData.RollParameretHash);
        StateMachine.IsRolling = false;
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (Time.time - rollStartTime < rollDuration)
        {
            RollMove(); // 롤 동작 중 이동
        }
        else
        {
            
            StateMachine.ChangeState(StateMachine.IdleState);
        }
    }

    private void RollMove()
    {
        
        Vector3 moveDirection = StateMachine.Player.transform.forward; // 전방으로 이동
        StateMachine.Player.Controller.Move(moveDirection * (rollDistance / rollDuration) * Time.deltaTime);
    }
}
