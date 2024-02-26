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
        currentHealth = initialMaxHealth; // �ʱ� ü�� ����
    }

    //public override void TakeDamage(int damage)
    //{
    //    if (currentHealth <= 0) return; // �̹� ����� ��� ó������ ����

    //    currentHealth -= damage;
    //    OnHealthChanged?.Invoke(currentHealth);

    //    if (currentHealth <= 0)
    //    {
    //        IsDead = true;
    //        stateMachine.ChangeState(stateMachine.DeadState);
            
    //    }
    //}
}
