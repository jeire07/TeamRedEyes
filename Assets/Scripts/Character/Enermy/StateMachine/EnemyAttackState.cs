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
    private float attackCooldown = 2.0f;
    private float lastAttackTime = 0f;


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

        float normalizedTime = GetNormalizedTime(stateMachine.Enemy.Animator, "Z_Attack");

        if (normalizedTime < 1f && normalizedTime >= stateMachine.Enemy.Data.ForceTransitionTime && !alreadyAppliedForce)
        {
            TryApplyForce();
            ApplyDamageToPlayer();
        }

        if (normalizedTime >= 1f && !isAnimationCompleted)
        {
            isAnimationCompleted = true;
            DecideNextAction();
        }

        if (!IsInAttackRange() && IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
        }
    }

    private void DecideNextAction()
    {
        if (IsInAttackRange() && Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            stateMachine.ChangeState(stateMachine.AttackState);
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

    private void RotateTowardsPlayer()
    {
        Vector3 directionToPlayer = (stateMachine.Target.transform.position - stateMachine.Enemy.transform.position).normalized;
        directionToPlayer.y = 0;
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

    private void ApplyDamageToPlayer()
    {
        float distanceToPlayer = Vector3.Distance(stateMachine.Enemy.transform.position, stateMachine.Target.position);
        if (distanceToPlayer <= stateMachine.Enemy.Data.AttackRange)
        {
            Condition[] conditions = PlayerCondition.Instance.statData.Conditions;
            if (conditions != null)
            {
                conditions[(int)ConditionType.Infection].Add(2);
                conditions[(int)ConditionType.Health].Add(-5);  // To Do apply monster's level
            }
        }
    }
}
