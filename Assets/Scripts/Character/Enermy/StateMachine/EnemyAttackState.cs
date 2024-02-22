using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }
    private bool alreadyAppliedForce;
    private bool isAnimationCompleted = false;
    private bool alreadyAplliedDealing;
    private float attackCooldown = 2.0f; // 공격 쿨다운 시간을 2초로 설정
    private float lastAttackTime = 0f; // 마지막 공격 시간을 기록


    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0f;
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimationData.AttackParameterHash);
        isAnimationCompleted = false;
        alreadyAppliedForce = false;
        lastAttackTime = Time.time;
    }

    public override void Update()
    {
        base.Update();
        RotateTowardsPlayer();

        // 공격 애니메이션의 진행 상태를 확인
        float normalizedTime = GetNormalizedTime(stateMachine.Enemy.Animator, "Z_Attack");

        // 공격 동작 중에 힘을 적용합니다.
        if (normalizedTime < 1f && normalizedTime >= stateMachine.Enemy.Data.ForceTransitionTime && !alreadyAppliedForce)
        {
            TryApplyForce();
        }

        // 애니메이션이 완료되었는지 확인
        if (normalizedTime >= 1f && !isAnimationCompleted)
        {
            isAnimationCompleted = true;
            DecideNextAction();
        }

        // 플레이어가 공격 범위를 벗어난 경우 즉시 추격 상태로 전환
        if (!IsInAttackRange() && IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
        }
    }

    private void DecideNextAction()
    {
        // 플레이어가 공격 범위 내에 있으면, 공격 쿨다운을 확인하고 다시 공격합니다.
        if (IsInAttackRange() && Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time; // 공격 쿨다운 타이머를 리셋합니다.
            stateMachine.ChangeState(stateMachine.AttackState); // 다시 공격 상태로 전환합니다.
        }
        // 플레이어가 공격 범위 밖이지만 추격 범위 내에 있으면 추격 상태로 전환합니다.
        else if (IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
        }
        // 그 외의 경우, 대기 상태로 돌아갑니다.
        else
        {
            stateMachine.ChangeState(stateMachine.IdlingState);
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 directionToPlayer = (stateMachine.Target.transform.position - stateMachine.Enemy.transform.position).normalized;
        directionToPlayer.y = 0;  // Y축 회전을 무시하고 수평으로만 회전하도록 합니다.
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        stateMachine.Enemy.transform.rotation = Quaternion.Slerp(stateMachine.Enemy.transform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) return;
        alreadyAppliedForce = true;

        stateMachine.Enemy.ForceReceiver.Reset();

        stateMachine.Enemy.ForceReceiver.AddForce(stateMachine.Enemy.transform.forward * stateMachine.Enemy.Data.Force);

    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.AttackParameterHash);
        alreadyAppliedForce = false;
    }

}
