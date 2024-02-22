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

    // 애니메이션 토글 메소드를 추가하여 코드 중복을 줄임
    private void ToggleAnimation(bool isActive)
    {
        StartOrStopAnimation(stateMachine.Enemy.AnimationData.GroundParameterHash, isActive);
        StartOrStopAnimation(stateMachine.Enemy.AnimationData.IdleParameterHash, isActive);
    }

    // 애니메이션 시작과 중지 로직을 하나의 메소드로 합침
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

