using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    public EnemyDeadState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimationData.IsDeadParameterHash);
        stateMachine.IsAlive = false;
        GameObject.Destroy(stateMachine.Enemy.gameObject, 5f);
    }
}
