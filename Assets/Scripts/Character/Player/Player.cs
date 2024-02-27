using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public PlayerSO Data {  get; private set; }

    [field: Header("Animations")]

    [field: SerializeField] public PlayerAnimationData AnimationData {  get; private set; }

    [field: Header("Stats")]
    [field: SerializeField] private PlayerStatData playerStatData;
    [field: SerializeField] private Weapon weapon;

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInput Input { get; private set; }
    public CharacterController Controller { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }

    public PlayerStateMachine StateMachine;

    private void Awake()
    {
        AnimationData.Initialize();

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerInput>();
        Controller = GetComponent<CharacterController>();
        ForceReceiver = GetComponent<ForceReceiver>();

        StateMachine = new PlayerStateMachine(this);
    }

    private void Start()
    {
        StateMachine.ChangeState(StateMachine.IdleState);
        if (weapon != null)
        {
            weapon.SetPlayer(this);
        }
    }

    private void Update()
    {
        StateMachine.HandleInput();
        StateMachine.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.PhysicsUpdate();
    }

    public int GetCurrentAttack()
    {
        return playerStatData.Atk;
    }
}
