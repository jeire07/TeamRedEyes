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
            // 추적을 중단하고 Idle 상태로 전환하는 로직을 여기에 추가할 수 있습니다.
            StopChase();
        }

        UpdateStateTransition();
    }

    private void AdjustMovementSpeed()
    {
        // 이동 속도를 groundData에서 제공하는 뛰기 속도 조정값으로 설정합니다.
        stateMachine.MovementSpeedModifier = groundData.RunSpeedModifier;
    }

    public void StopChase()
    {
        // 이동 속도를 0으로 설정하여 추격을 중지합니다.
        stateMachine.MovementSpeedModifier = 0f;

        // 상태 머신을 통해 EnemyIdleState로 상태를 전환합니다.
        stateMachine.ChangeState(stateMachine.IdlingState);
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

    private void CheckForObstacles()
    {
        Vector3 startPosition = stateMachine.Enemy.transform.position + Vector3.up * 0.5f;
        Vector3 directionToPlayer = (stateMachine.Target.transform.position - startPosition).normalized;
        float distanceToPlayer = Vector3.Distance(stateMachine.Target.transform.position, startPosition);

        RaycastHit hit;
        if (Physics.Raycast(startPosition, directionToPlayer, out hit, distanceToPlayer, obstacleLayerMask))
        {
            Debug.DrawLine(startPosition, hit.point, Color.red);

            // 충돌한 객체에 대한 디버그 로그 출력
            Debug.Log("Obstacle Detected: " + hit.collider.gameObject.name);

            if (hit.collider.gameObject != stateMachine.Target.gameObject)
            {
                // 장애물이 플레이어가 아닐 경우
                stateMachine.SetObstacleDetected(true);
            }
            else
            {
                // 직접 경로상에 플레이어가 있을 경우
                stateMachine.SetObstacleDetected(false);
            }
        }
        else
        {
            // 경로상에 장애물이 없을 경우
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
        lookDirection.y = 0; // Y축 회전 무시
        Quaternion rotation = Quaternion.LookRotation(lookDirection);
        stateMachine.Enemy.transform.rotation = Quaternion.Slerp(stateMachine.Enemy.transform.rotation, rotation, stateMachine.RotationDamping * Time.deltaTime);
    }
}

