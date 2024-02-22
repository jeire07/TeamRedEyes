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
    private float attackCooldown = 2.0f; // ���� ��ٿ� �ð��� 2�ʷ� ����
    private float lastAttackTime = 0f; // ������ ���� �ð��� ���


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

        // ���� �ִϸ��̼��� ���� ���¸� Ȯ��
        float normalizedTime = GetNormalizedTime(stateMachine.Enemy.Animator, "Z_Attack");

        // ���� ���� �߿� ���� �����մϴ�.
        if (normalizedTime < 1f && normalizedTime >= stateMachine.Enemy.Data.ForceTransitionTime && !alreadyAppliedForce)
        {
            TryApplyForce();
        }

        // �ִϸ��̼��� �Ϸ�Ǿ����� Ȯ��
        if (normalizedTime >= 1f && !isAnimationCompleted)
        {
            isAnimationCompleted = true;
            DecideNextAction();
        }

        // �÷��̾ ���� ������ ��� ��� ��� �߰� ���·� ��ȯ
        if (!IsInAttackRange() && IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
        }
    }

    private void DecideNextAction()
    {
        // �÷��̾ ���� ���� ���� ������, ���� ��ٿ��� Ȯ���ϰ� �ٽ� �����մϴ�.
        if (IsInAttackRange() && Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time; // ���� ��ٿ� Ÿ�̸Ӹ� �����մϴ�.
            stateMachine.ChangeState(stateMachine.AttackState); // �ٽ� ���� ���·� ��ȯ�մϴ�.
        }
        // �÷��̾ ���� ���� �������� �߰� ���� ���� ������ �߰� ���·� ��ȯ�մϴ�.
        else if (IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
        }
        // �� ���� ���, ��� ���·� ���ư��ϴ�.
        else
        {
            stateMachine.ChangeState(stateMachine.IdlingState);
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 directionToPlayer = (stateMachine.Target.transform.position - stateMachine.Enemy.transform.position).normalized;
        directionToPlayer.y = 0;  // Y�� ȸ���� �����ϰ� �������θ� ȸ���ϵ��� �մϴ�.
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
