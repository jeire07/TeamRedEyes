using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StateMachine.MovementspeedModifier = 0f;
        StartAnimation(StateMachine.Player.AnimationData.AttackParameterHash);
        StateMachine.IsAttacking = true;
        StateMachine.Player.Weapon.ActivateAttack(true);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(StateMachine.Player.AnimationData.AttackParameterHash);
        StateMachine.IsAttacking = false;
        StateMachine.Player.Weapon.ActivateAttack(false);
    }
}
