using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyBaseState
{
    private readonly int walkAnimationHash;

    public EnemyWalkState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
        // 애니메이션 해시 값을 미리 계산하여 저장
        walkAnimationHash = Animator.StringToHash("Z_Walk");
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier;

        // Animator에 대한 직접 접근 대신 애니메이션 재생을 위한 메서드 호출
        PlayWalkAnimation();
    }

    public override void Exit()
    {
        base.Exit();
        StopWalkAnimation();
    }

    private void PlayWalkAnimation()
    {
        // 애니메이션 재생을 위한 메서드에서 Animator의 SetBool을 사용
        stateMachine.Enemy.Animator.SetBool(walkAnimationHash, true);
    }

    private void StopWalkAnimation()
    {
        // 애니메이션 중지를 위한 메서드에서 Animator의 SetBool을 사용
        stateMachine.Enemy.Animator.SetBool(walkAnimationHash, false);
    }

    // 필요한 경우 Update 메서드를 여기에 구현
    // 예: 플레이어 추적 로직, 상태 전환 조건 등
}
