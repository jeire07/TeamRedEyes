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
    public Transform BaseHumanLArmPalm;
    public Transform BaseHumanRArmPalm;

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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Weapon"))
    //    {
    //        Weapon weapon = other.GetComponent<Weapon>();
    //        if (weapon != null && weapon.isAttacking) // IsAttacking은 공개 속성이어야 합니다.
    //        {
    //            float damage = weapon.Damage;
    //            TakeDamage(damage);
    //        }
    //    }
    //}

    private void HandleHealthChanged(float healthPercentage)
    {
 
    }
    private void HandleDeath()
    {

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        HandleHealthChanged(currentHealth / Data.MaxHealth);

        if (currentHealth <= 0)
        {
            stateMachine.ChangeState(stateMachine.DeadState);
            StatManager.Instance.GainExp();
        }
    }

    public void StopMovementTemporary()
    {
        if (stateMachine != null)
        {
            stateMachine.StopMovementTemporary();
        }
    }


}
