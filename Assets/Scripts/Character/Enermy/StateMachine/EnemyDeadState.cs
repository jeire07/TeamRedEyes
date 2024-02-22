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
        StartAnimation(stateMachine.Enemy.AnimationData.IsDeadParameterHash); // 사망 애니메이션 재생 시작
        GameObject.Destroy(stateMachine.Enemy.gameObject, 30f);
    }
}
