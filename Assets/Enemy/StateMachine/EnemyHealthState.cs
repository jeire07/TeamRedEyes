using UnityEngine;

public class EnemyHealthState : EnemyBaseState
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;

    public EnemyHealthState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    // 이벤트들 - 필요에 따라 추가
    public delegate void HealthChanged(int currentHealth);
    public event HealthChanged OnHealthChanged;

    public delegate void Died();
    public event Died OnDied;

    public void Start()
    {
        currentHealth = maxHealth; // 상태 머신 초기화
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // 이미 죽었다면 더 이상 체력을 감소시키지 않음

        currentHealth -= damage;
        OnHealthChanged?.Invoke(currentHealth); // 체력 변화 이벤트 발생

        StartAnimation(stateMachine.Enemy.AnimationData.HitParameterHash);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return; // 이미 사망한 상태라면 이 함수를 더 이상 진행하지 않음
        isDead = true;

        stateMachine.ChangeState(stateMachine.DeadState); // 상태 머신을 통해 사망 상태로 전환
        OnDied?.Invoke(); // 사망 이벤트 발생
    }

    public void Heal(int healAmount)
    {
        if (isDead) return; // 이미 죽었다면 회복되지 않음

        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 체력을 최대치를 넘지 않도록 제한
        OnHealthChanged?.Invoke(currentHealth); // 체력 변화 이벤트 발생
    }
}
