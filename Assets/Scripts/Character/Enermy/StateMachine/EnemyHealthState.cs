using System;
using UnityEngine;

public class EnemyHealthState : EnemyBaseState
{
    private int MaxHealth;
    private int currentHealth;
    private bool IsDead = false;
    public event Action<int> OnHealthChanged;

    public EnemyHealthState(EnemyStateMachine enemyStateMachine, int initialMaxHealth) : base(enemyStateMachine)
    {
        currentHealth = initialMaxHealth; // 초기 체력 설정
    }

    //public override void TakeDamage(int damage)
    //{
    //    if (currentHealth <= 0) return; // 이미 사망한 경우 처리하지 않음

    //    currentHealth -= damage;
    //    OnHealthChanged?.Invoke(currentHealth);

    //    if (currentHealth <= 0)
    //    {
    //        IsDead = true;
    //        stateMachine.ChangeState(stateMachine.DeadState);
            
    //    }
    //}
}
