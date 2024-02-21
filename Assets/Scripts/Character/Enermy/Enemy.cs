using UnityEngine;
using UnityEngine.ProBuilder;

public class Enemy : MonoBehaviour
{
    [field: Header("Referense")]
    [field: SerializeField] public EnemySO Data { get; private set; }
    [field: SerializeField] private float currentHealth;

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
        currentHealth = Data.MaxHealth;

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

    private void OnTriggerEnter(Collider other)
    {
        // 데미지를 주는 오브젝트의 태그
        if (other.CompareTag("Weapon"))
        {
            //  컴포넌트에서 데미지 양을 가져옵니다.
            float damage = other.GetComponent<Weapon>().Damage;
            ReceiveDamage(damage);
        }
    }

    // 적이 데미지를 받았을 때 호출될 메서드
    public void ReceiveDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Enemy health: {currentHealth}/{Data.MaxHealth}");

        // 체력이 변경될 때 처리
        HandleHealthChanged(currentHealth / Data.MaxHealth);

        // 체력이 0 이하이면 적 사망 처리
        if (currentHealth <= 0)
        {
            stateMachine.ChangeState(stateMachine.DeadState);
        }
    }

    // 체력이 변경될 때 처리할 메서드
    private void HandleHealthChanged(float healthPercentage)
    {
        // 체력 바 업데이트 등의 로직을 여기에 구현
        Debug.Log($"Enemy health changed: {healthPercentage * 100}%");
    }

    // 적이 사망했을 때 처리할 메서드
    private void HandleDeath()
    {

    }
}
