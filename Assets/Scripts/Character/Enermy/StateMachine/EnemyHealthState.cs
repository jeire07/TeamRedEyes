using System;
using UnityEngine;

public class EnemyHealthState : EnemyBaseState
{
    private int currentHealth;
 
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
