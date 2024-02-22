using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine) { }

    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier = 0f;
        ToggleAnimation(true);
    }

    public override void Exit()
    {
        base.Exit();
        ToggleAnimation(false);
    }

    public override void Update()
    {
        if (IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
        }
    }

    // �ִϸ��̼� ��� �޼ҵ带 �߰��Ͽ� �ڵ� �ߺ��� ����
    private void ToggleAnimation(bool isActive)
    {
        StartOrStopAnimation(stateMachine.Enemy.AnimationData.GroundParameterHash, isActive);
        StartOrStopAnimation(stateMachine.Enemy.AnimationData.IdleParameterHash, isActive);
    }

    // �ִϸ��̼� ���۰� ���� ������ �ϳ��� �޼ҵ�� ��ħ
    private void StartOrStopAnimation(int hash, bool shouldStart)
    {
        if (shouldStart)
        {
            StartAnimation(hash);
        }
        else
        {
            StopAnimation(hash);
        }
    }
}

