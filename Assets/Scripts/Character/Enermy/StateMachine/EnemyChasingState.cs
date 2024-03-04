using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    public EnemyChasingState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine) { }

    public override void Enter()
    {
        base.Enter();
        AdjustMovementSpeed();
        StartAnimation(stateMachine.Enemy.AnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.RunParameterHash);
    }

    public override void Update()
    {
        base.Update();
        UpdateStateTransition();
        ChasePlayer();
    }

    private void AdjustMovementSpeed()
    {
        // 이동 속도를 groundData에서 제공하는 뛰기 속도 조정값으로 설정합니다.
        stateMachine.MovementSpeedModifier = groundData.RunSpeedModifier;
    }

    private void UpdateStateTransition()
    {
        if (!stateMachine.IsAlive) return;

        // 공격 범위 내에 있으면 공격 상태로 전환합니다.
        if (IsInAttackRange())
        {
            stateMachine.ChangeState(stateMachine.AttackState);
        }
        // 추적 범위 밖으로 벗어나면 대기 상태로 전환합니다.
        else if (!IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.IdlingState);
        }
    }

    private void ChasePlayer()
    {
        if (!stateMachine.IsAlive) return;

        // 플레이어를 향해 이동합니다.
        Vector3 playerPosition = stateMachine.Target.transform.position;
        Vector3 direction = (playerPosition - stateMachine.Enemy.transform.position).normalized;
        stateMachine.Enemy.Controller.Move(direction * stateMachine.MovementSpeed * Time.deltaTime);

        // 플레이어를 향해 회전합니다.
        Vector3 lookDirection = playerPosition - stateMachine.Enemy.transform.position;
        lookDirection.y = 0; // Y축 회전 무시
        Quaternion rotation = Quaternion.LookRotation(lookDirection);
        stateMachine.Enemy.transform.rotation = Quaternion.Slerp(stateMachine.Enemy.transform.rotation, rotation, stateMachine.RotationDamping * Time.deltaTime);
    }
}
