using System;
using UnityEngine;

public class EnemyHealthState : EnemyBaseState
{
    private int maxHealth;
    private int currentHealth;
    private bool isDead = false;

    public event Action<int> OnHealthChanged;
    public event Action OnDied;


    public EnemyHealthState(EnemyStateMachine enemyStateMachine, int initialMaxHealth) : base(enemyStateMachine)
    {
        maxHealth = initialMaxHealth;
        currentHealth = maxHealth;
    }

    public override void Enter()
    {
        base.Enter();
        isDead = false; // 사망 상태 초기화
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // 이미 죽었다면 더 이상 처리하지 않음

        currentHealth -= damage;
        OnHealthChanged?.Invoke(currentHealth); // 체력 변화 이벤트 발생

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // 피격 애니메이션 재생
            StartAnimation(stateMachine.Enemy.AnimationData.HitParameterHash);
        }
    }

    private void Die()
    {
  
    }

}
