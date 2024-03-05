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
        // �̵� �ӵ��� groundData���� �����ϴ� �ٱ� �ӵ� ���������� �����մϴ�.
        stateMachine.MovementSpeedModifier = groundData.RunSpeedModifier;
    }

    private void UpdateStateTransition()
    {
        if (!stateMachine.IsAlive) return;

        // ���� ���� ���� ������ ���� ���·� ��ȯ�մϴ�.
        if (IsInAttackRange())
        {
            stateMachine.ChangeState(stateMachine.AttackState);
        }
        // ���� ���� ������ ����� ��� ���·� ��ȯ�մϴ�.
        else if (!IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.IdlingState);
        }
    }

    private void ChasePlayer()
    {
        if (!stateMachine.IsAlive) return;

        // �÷��̾ ���� �̵��մϴ�.
        Vector3 playerPosition = stateMachine.Target.transform.position;
        Vector3 direction = (playerPosition - stateMachine.Enemy.transform.position).normalized;
        stateMachine.Enemy.Controller.Move(direction * stateMachine.MovementSpeed * Time.deltaTime);

        // �÷��̾ ���� ȸ���մϴ�.
        Vector3 lookDirection = playerPosition - stateMachine.Enemy.transform.position;
        lookDirection.y = 0; // Y�� ȸ�� ����
        Quaternion rotation = Quaternion.LookRotation(lookDirection);
        stateMachine.Enemy.transform.rotation = Quaternion.Slerp(stateMachine.Enemy.transform.rotation, rotation, stateMachine.RotationDamping * Time.deltaTime);
    }
}
