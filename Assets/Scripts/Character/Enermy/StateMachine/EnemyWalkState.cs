using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyBaseState
{
    private readonly int walkAnimationHash;

    public EnemyWalkState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
        // �ִϸ��̼� �ؽ� ���� �̸� ����Ͽ� ����
        walkAnimationHash = Animator.StringToHash("Z_Walk");
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier;

        // Animator�� ���� ���� ���� ��� �ִϸ��̼� ����� ���� �޼��� ȣ��
        PlayWalkAnimation();
    }

    public override void Exit()
    {
        base.Exit();
        StopWalkAnimation();
    }

    private void PlayWalkAnimation()
    {
        // �ִϸ��̼� ����� ���� �޼��忡�� Animator�� SetBool�� ���
        stateMachine.Enemy.Animator.SetBool(walkAnimationHash, true);
    }

    private void StopWalkAnimation()
    {
        // �ִϸ��̼� ������ ���� �޼��忡�� Animator�� SetBool�� ���
        stateMachine.Enemy.Animator.SetBool(walkAnimationHash, false);
    }

    // �ʿ��� ��� Update �޼��带 ���⿡ ����
    // ��: �÷��̾� ���� ����, ���� ��ȯ ���� ��
}
