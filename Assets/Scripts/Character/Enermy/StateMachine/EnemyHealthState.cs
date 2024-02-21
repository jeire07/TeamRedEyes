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
        isDead = false; // ��� ���� �ʱ�ȭ
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // �̹� �׾��ٸ� �� �̻� ó������ ����

        currentHealth -= damage;
        OnHealthChanged?.Invoke(currentHealth); // ü�� ��ȭ �̺�Ʈ �߻�

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // �ǰ� �ִϸ��̼� ���
            StartAnimation(stateMachine.Enemy.AnimationData.HitParameterHash);
        }
    }

    private void Die()
    {
  
    }

}
