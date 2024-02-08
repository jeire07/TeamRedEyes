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

        float normalizedTime = GetNormalizedTime(stateMachine.Enemy.Animator, "Attack");

        if (normalizedTime < 1f)
        {
            if (normalizedTime >= stateMachine.Enemy.Data.ForceTransitionTime && !alreadyAppliedForce)
            {
                TryApplyForce();
            }
        }
        else if (!isAnimationCompleted)
        {
            isAnimationCompleted = true;

            if (IsInAttackRange())
            {
                if (Time.time - lastAttackTime > attackCooldown)
                {
                    lastAttackTime = Time.time;
                    stateMachine.ChangeState(stateMachine.AttackState);
                }
                // 추가: 쿨다운이 지나지 않았다면 추격 상태로 전환
                else if (IsInChaseRange())
                {
                    stateMachine.ChangeState(stateMachine.ChasingState);
                }
            }
            else if (IsInChaseRange())
            {
                stateMachine.ChangeState(stateMachine.ChasingState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.IdlingState);
            }
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
