using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{

    public Enemy Enemy { get; }

    public Transform Target { get; private set; }
    public EnemyIdleState IdlingState { get; set; }
    public EnemyChasingState ChasingState { get; set; }
    public EnemyAttackState AttackState { get; set; }
    public EnemyDeadState DeadState { get; set; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

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

}
