using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollState : PlayerGroundState
{
    private float rollDuration = 0.5f; // �� ������ ���� �ð�
    private float rollStartTime;
    private float rollDistance = 2f; // �� �������� �̵��� �Ÿ�

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
            RollMove(); // �� ���� �� �̵�
        }
        else
        {
            if (StateMachine.Player.Controller.isGrounded)
            {
                StateMachine.ChangeState(StateMachine.IdleState); // �� �Ϸ� �� ���鿡 ������ Idle ���·� ��ȯ
            }
            else
            {
                StateMachine.ChangeState(StateMachine.FallState); // �� �Ϸ� �� ���鿡 ������ Fall ���·� ��ȯ
            }
        }
    }

    private void RollMove()
    {
        
        Vector3 moveDirection = StateMachine.Player.transform.forward; // �������� �̵�
        StateMachine.Player.Controller.Move(moveDirection * (rollDistance / rollDuration) * Time.deltaTime);
    }
}
