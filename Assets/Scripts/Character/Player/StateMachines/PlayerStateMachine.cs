using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }

    public PlayerIdleState IdleState { get; }
    public PlayerWalkState WalkState { get; }
    public PlayerRunState RunState { get; }
    public PlayerJumpState JumpState { get; }
    public PlayerFallState FallState { get; }
    public PlayerRollState RollState { get; }
    public PlayerSitState SitState { get; }
    public PlayerComboAttackState ComboAttackState { get; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementspeedModifier { get; set; } = 1f;
    public bool IsRolling { get; set; }
    public bool IsSitting { get; set; }
    public bool IsAttacking { get; set; }
    public int ComboIndex { get; set; }

    public float JumpForce { get; set; }
    public Transform MainCameraTransform { get; set; }

    public PlayerDeadState DeadState{ get; set; }


    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        IdleState = new PlayerIdleState(this);
        WalkState = new PlayerWalkState(this);
        RunState = new PlayerRunState(this);
        JumpState = new PlayerJumpState(this);
        FallState = new PlayerFallState(this);
        RollState = new PlayerRollState(this);
        SitState = new PlayerSitState(this);
        ComboAttackState = new PlayerComboAttackState(this);
        DeadState = new PlayerDeadState(this);

        MainCameraTransform = Camera.main.transform;

        MovementSpeed = player.Data.GroundData.BaseSpeed;

        RotationDamping = player.Data.GroundData.BaseRotationDamping;

        IsRolling = false;
        IsSitting = false;
        
    }
 
}
