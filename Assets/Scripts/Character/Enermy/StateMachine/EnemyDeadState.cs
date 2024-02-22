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
        StartAnimation(stateMachine.Enemy.AnimationData.IsDeadParameterHash); // ��� �ִϸ��̼� ��� ����
        GameObject.Destroy(stateMachine.Enemy.gameObject, 30f);
    }
}
