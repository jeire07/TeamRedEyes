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

    // 애니메이션 토글 메소드를 추가하여 코드 중복을 줄임
    private void ToggleAnimation(bool isActive)
    {
        StartOrStopAnimation(stateMachine.Enemy.AnimationData.GroundParameterHash, isActive);
        StartOrStopAnimation(stateMachine.Enemy.AnimationData.IdleParameterHash, isActive);
    }

    // 애니메이션 시작과 중지 로직을 하나의 메소드로 합침
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

        // "Interactable" 및 "NotInteractable" 레이어를 포함하는 레이어 마스크 설정
        int layerMask = LayerMask.GetMask("Interactable", "NotInteractable");

        RaycastHit hit;
        // 플레이어 방향으로 레이캐스트 발사
        if (Physics.Raycast(startPosition, directionToPlayer, out hit, distanceToPlayer, layerMask))
        {
            Debug.DrawLine(startPosition, hit.point, Color.red);
            // 레이캐스트가 "Interactable" 또는 "NotInteractable" 오브젝트에 맞았다면, 플레이어가 가로막혔음을 의미
            Debug.Log($"View to player blocked by {hit.collider.gameObject.name}");
            return false; // 플레이어를 볼 수 없으므로 chasing 상태로 전환하지 않음
        }

        // 장애물이 없다면 true 반환
        return true; // 플레이어를 볼 수 있으므로 chasing 상태로 전환 가능
    }
}

