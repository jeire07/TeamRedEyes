using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{

    public Enemy Enemy { get; }
    public bool IsAlive = true;

    public Transform Target { get; private set; }
    public EnemyIdleState IdlingState { get; set; }
    public EnemyChasingState ChasingState { get; set; }
    public EnemyAttackState AttackState { get; set; }
    public EnemyDeadState DeadState { get; set; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;
    public bool IsBlockedByObstacle { get; private set; } = false;

    public EnemyBaseState CurrentState { get; private set; }

    public EnemyStateMachine(Enemy enemy)
    {
        Enemy = enemy;
        Target = GameObject.FindGameObjectWithTag("Player").transform;

        IdlingState = new EnemyIdleState(this);
        ChasingState = new EnemyChasingState(this);
        AttackState = new EnemyAttackState(this);
        DeadState = new EnemyDeadState(this);

        MovementSpeed = enemy.Data.EnemyGroundData.BaseSpeed;
        RotationDamping = enemy.Data.EnemyGroundData.BaseRotationDamping;
    }

    public void SetObstacleDetected(bool isBlocked)
    {
        IsBlockedByObstacle = isBlocked;
    }

    public void StopMovementTemporary()
    {
        // 이동을 일시적으로 중지시키는 로직을 구현합니다.
        // 예를 들어, 현재 상태가 추격 상태일 때만 이동을 중지시키려면
        if (currentState is EnemyChasingState)
        {
            ChasingState.StopChase();
            // 이동 중지 로직을 구현합니다.
            // 예: 현재 속도를 0으로 설정하거나, 특정 플래그를 사용하여 Update에서 이동 처리를 건너뛰게 합니다.
        }
    }

}
