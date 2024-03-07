using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    public LayerMask obstacleLayerMask;

    public EnemyChasingState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {

        obstacleLayerMask = LayerMask.GetMask("Interactable", "NotInteractable");
    }

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

        if (!stateMachine.IsAlive)
        {
            return;
        }

        CheckForObstacles();

        if (!stateMachine.IsBlockedByObstacle)
        {
            ChasePlayer();
        }
        else
        {
            // ������ �ߴ��ϰ� Idle ���·� ��ȯ�ϴ� ������ ���⿡ �߰��� �� �ֽ��ϴ�.
            StopChase();
        }

        UpdateStateTransition();
    }

    private void AdjustMovementSpeed()
    {
        // �̵� �ӵ��� groundData���� �����ϴ� �ٱ� �ӵ� ���������� �����մϴ�.
        stateMachine.MovementSpeedModifier = groundData.RunSpeedModifier;
    }

    public void StopChase()
    {
        // �̵� �ӵ��� 0���� �����Ͽ� �߰��� �����մϴ�.
        stateMachine.MovementSpeedModifier = 0f;

        // ���� �ӽ��� ���� EnemyIdleState�� ���¸� ��ȯ�մϴ�.
        stateMachine.ChangeState(stateMachine.IdlingState);
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

    private void CheckForObstacles()
    {
        Vector3 startPosition = stateMachine.Enemy.transform.position + Vector3.up * 0.5f;
        Vector3 directionToPlayer = (stateMachine.Target.transform.position - startPosition).normalized;
        float distanceToPlayer = Vector3.Distance(stateMachine.Target.transform.position, startPosition);

        RaycastHit hit;
        if (Physics.Raycast(startPosition, directionToPlayer, out hit, distanceToPlayer, obstacleLayerMask))
        {
            Debug.DrawLine(startPosition, hit.point, Color.red);

            // �浹�� ��ü�� ���� ����� �α� ���
            Debug.Log("Obstacle Detected: " + hit.collider.gameObject.name);

            if (hit.collider.gameObject != stateMachine.Target.gameObject)
            {
                // ��ֹ��� �÷��̾ �ƴ� ���
                stateMachine.SetObstacleDetected(true);
            }
            else
            {
                // ���� ��λ� �÷��̾ ���� ���
                stateMachine.SetObstacleDetected(false);
            }
        }
        else
        {
            // ��λ� ��ֹ��� ���� ���
            stateMachine.SetObstacleDetected(false);
        }
    }

    private void ChasePlayer()
    {
        if (!stateMachine.IsAlive || stateMachine.IsBlockedByObstacle) return;
        //if (!stateMachine.IsAlive) return;

        Vector3 playerPosition = stateMachine.Target.transform.position;
        Vector3 direction = (playerPosition - stateMachine.Enemy.transform.position).normalized;
        stateMachine.Enemy.Controller.Move(direction * stateMachine.MovementSpeed * Time.deltaTime);

        Vector3 lookDirection = playerPosition - stateMachine.Enemy.transform.position;
        lookDirection.y = 0; // Y�� ȸ�� ����
        Quaternion rotation = Quaternion.LookRotation(lookDirection);
        stateMachine.Enemy.transform.rotation = Quaternion.Slerp(stateMachine.Enemy.transform.rotation, rotation, stateMachine.RotationDamping * Time.deltaTime);
    }
}

