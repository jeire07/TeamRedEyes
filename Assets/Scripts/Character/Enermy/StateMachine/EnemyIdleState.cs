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
        if (CanSeePlayerWithoutObstacles())
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

    private bool CanSeePlayerWithoutObstacles()
    {
        Vector3 startPosition = stateMachine.Enemy.transform.position + Vector3.up * 2.0f;
        Vector3 directionToPlayer = stateMachine.Target.transform.position - stateMachine.Enemy.transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;
        directionToPlayer.Normalize();

        // "Interactable" �� "NotInteractable" ���̾ �����ϴ� ���̾� ����ũ ����
        int layerMask = LayerMask.GetMask("Interactable", "NotInteractable");

        RaycastHit hit;
        // �÷��̾� �������� ����ĳ��Ʈ �߻�
        if (Physics.Raycast(startPosition, directionToPlayer, out hit, distanceToPlayer, layerMask))
        {
            Debug.DrawLine(startPosition, hit.point, Color.red);
            // ����ĳ��Ʈ�� "Interactable" �Ǵ� "NotInteractable" ������Ʈ�� �¾Ҵٸ�, �÷��̾ ���θ������� �ǹ�
            Debug.Log($"View to player blocked by {hit.collider.gameObject.name}");
            return false; // �÷��̾ �� �� �����Ƿ� chasing ���·� ��ȯ���� ����
        }

        // ��ֹ��� ���ٸ� true ��ȯ
        return true; // �÷��̾ �� �� �����Ƿ� chasing ���·� ��ȯ ����
    }
}

