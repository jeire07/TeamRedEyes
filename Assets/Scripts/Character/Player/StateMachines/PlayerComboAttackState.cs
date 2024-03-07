
public class PlayerComboAttackState : PlayerAttackState
{
    private bool alreadyAppliedForce;
    private bool alreadyApplyCombo;
    AttackInfoData attackInfoData;

    public PlayerComboAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(StateMachine.Player.AnimationData.ComboAttackParameterHash);

        alreadyAppliedForce = false;
        alreadyApplyCombo = false;

        int comboIndex = StateMachine.ComboIndex;
        attackInfoData = StateMachine.Player.Data.AttackData.GetAttackInfo(comboIndex);
        StateMachine.Player.Animator.SetInteger("Combo", comboIndex);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(StateMachine.Player.AnimationData.ComboAttackParameterHash);

        if (alreadyApplyCombo)
            StateMachine.ComboIndex = 0;
    }

    private void TryComboAttack()
    {
        if (alreadyApplyCombo) return;
        if (attackInfoData.ComboSateIndex == -1) return;
        if (!StateMachine.IsAttacking) return;
        alreadyApplyCombo = true;
    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) return;
        alreadyAppliedForce = true;

        StateMachine.Player.ForceReceiver.Reset();
        StateMachine.Player.ForceReceiver.AddForce(StateMachine.Player.transform.forward * attackInfoData.Force);
    }

    public override void Update()
    {
        base.Update();

        ForceMove();

        float nomalizedtime = GetNomarlizedTime(StateMachine.Player.Animator, "Attack");
        if (nomalizedtime < 1f)
        {
            if(nomalizedtime >= attackInfoData.ForceTransitionTime)
                TryApplyForce();
            if (nomalizedtime >= attackInfoData.ComboTransitionTime)
                TryComboAttack();
        }
        else
        {
          if(alreadyApplyCombo)
            {
                StateMachine.ComboIndex = attackInfoData.ComboSateIndex;
                StateMachine.ChangeState(StateMachine.ComboAttackState);
            }
            else
            {
                StateMachine.ChangeState(StateMachine.IdleState);
            }
        }

    }
}
