using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class PlayerAnimationData
{
    [SerializeField] private string groundParameterName = "@Ground";
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string walkParameterName = "Walk";
    [SerializeField] private string runParameterName = "Run";
    [SerializeField] private string rollParameterName = "Roll";
    [SerializeField] private string sitParameterName = "Sit";

    [SerializeField] private string airParameterName = "@Air";
    [SerializeField] private string jumpParameterName = "Jump";
    [SerializeField] private string fallParameterName = "Fall";

    [SerializeField] private string attackParameterName = "@Attack";
    [SerializeField] private string baseattackParameterName = "baseAttack";
    [SerializeField] private string comboattackParameterName = "ComboAttack";
    [SerializeField] private string smashParameterName = "Smash";
    [SerializeField] private string defenseParameterName = "Defense";

    public int GroundParameterHash {  get; private set; }
    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }
    public int RollParameretHash { get; private set; }
    public int SitParameterHash { get; private set; }

    public int AirParameterHash { get; private set; }
    public int JumpParameterHash { get; private set; }
    public int FallParameterHash { get; private set; }

    public int AttackParameterHash { get; private set; }
    public int BaseAttackParameterHash { get; private set; }
    public int ComboAttackParameterHash { get; private set; }
    public int SmashParameterHash { get; private set; }
    public int DefenseParameterHash { get; private set; }

    public void Initialize()
    {
        GroundParameterHash = Animator.StringToHash(groundParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        WalkParameterHash = Animator.StringToHash(walkParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);
        RollParameretHash = Animator.StringToHash(rollParameterName);
        SitParameterHash = Animator.StringToHash(sitParameterName);

        AirParameterHash = Animator.StringToHash(airParameterName);
        JumpParameterHash = Animator.StringToHash(jumpParameterName);
        FallParameterHash = Animator.StringToHash(fallParameterName);

        AttackParameterHash = Animator.StringToHash(attackParameterName);
        BaseAttackParameterHash = Animator.StringToHash(baseattackParameterName);
        ComboAttackParameterHash = Animator.StringToHash(comboattackParameterName);
        SmashParameterHash = Animator.StringToHash(smashParameterName);
        DefenseParameterHash = Animator.StringToHash(defenseParameterName);
    }
}
