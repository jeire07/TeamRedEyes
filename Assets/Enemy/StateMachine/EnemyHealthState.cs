using UnityEngine;

public class EnemyHealthState : EnemyBaseState
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;

    public EnemyHealthState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    // �̺�Ʈ�� - �ʿ信 ���� �߰�
    public delegate void HealthChanged(int currentHealth);
    public event HealthChanged OnHealthChanged;

    public delegate void Died();
    public event Died OnDied;

    public void Start()
    {
        currentHealth = maxHealth; // ���� �ӽ� �ʱ�ȭ
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // �̹� �׾��ٸ� �� �̻� ü���� ���ҽ�Ű�� ����

        currentHealth -= damage;
        OnHealthChanged?.Invoke(currentHealth); // ü�� ��ȭ �̺�Ʈ �߻�

        StartAnimation(stateMachine.Enemy.AnimationData.HitParameterHash);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return; // �̹� ����� ���¶�� �� �Լ��� �� �̻� �������� ����
        isDead = true;

        stateMachine.ChangeState(stateMachine.DeadState); // ���� �ӽ��� ���� ��� ���·� ��ȯ
        OnDied?.Invoke(); // ��� �̺�Ʈ �߻�
    }

    public void Heal(int healAmount)
    {
        if (isDead) return; // �̹� �׾��ٸ� ȸ������ ����

        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // ü���� �ִ�ġ�� ���� �ʵ��� ����
        OnHealthChanged?.Invoke(currentHealth); // ü�� ��ȭ �̺�Ʈ �߻�
    }
}
