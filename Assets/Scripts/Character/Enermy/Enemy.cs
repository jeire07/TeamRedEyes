using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: Header("Referense")]
    [field: SerializeField] public EnemySO Data { get; private set; }

    [field: Header("Animations")]
    [field: SerializeField] public EnemyAnimationData AnimationData { get; private set; }

    //public EnemyStats Stats { get; private set; }

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }
    public CharacterController Controller { get; private set; }

    private EnemyStateMachine stateMachine;

    private void Awake()
    {
        AnimationData.Initialize();

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        Controller = GetComponent<CharacterController>();
        ForceReceiver = GetComponent<ForceReceiver>();

        //Stats = new EnemyStats(); // EnemyStats �ν��Ͻ� ����
        //Stats.OnHealthChanged += HandleHealthChanged; // ü�� ���� �̺�Ʈ ����
        //Stats.OnDie += HandleDeath; // ��� �̺�Ʈ ����

        stateMachine = new EnemyStateMachine(this);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdlingState);
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    // ���� �������� �޾��� �� ȣ��� �޼���
    public void ReceiveDamage(float damage)
    {
        //Stats.TakeDamage(damage);
    }

    // ü���� ����� �� ó���� �޼���
    private void HandleHealthChanged(float healthPercentage)
    {
        // ü�� �� ������Ʈ ���� ������ ���⿡ ����
        Debug.Log($"Enemy health changed: {healthPercentage * 100}%");
    }

    // ���� ������� �� ó���� �޼���
    private void HandleDeath()
    {
        // �� ��� ó�� ������ ���⿡ ����
        Debug.Log("Enemy died.");
    }
}