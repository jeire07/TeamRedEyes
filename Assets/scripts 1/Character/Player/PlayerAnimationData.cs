using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class PlayerAnimationData
{
    [SerializeField] private string groundParametarName = "@Ground";
    [SerializeField] private string idleParametarName = "Idle";
    [SerializeField] private string walkParametarName = "Walk";
    [SerializeField] private string runParametarName = "Run";
    [SerializeField] private string rollParametarName = "Roll";
    [SerializeField] private string sitParametarName = "Sit";

    [SerializeField] private string airParameterName = "@Air";
    [SerializeField] private string jumpParametarName = "Jump";
    [SerializeField] private string fallParametarName = "Fall";

    [SerializeField] private string attackParametarName = "@Attack";
    [SerializeField] private string comboattackParametarName = "ComboAttack";
    [SerializeField] private string smashParametarName = "Smash";
    [SerializeField] private string defenseParameterName = "Defense";

    public int GroundParametarHash {  get; private set; }
    public int IdleParametarHash { get; private set; }
    public int WalkParametarHash { get; private set; }
    public int RunParametarHash { get; private set; }
    public int RollParameratHash { get; private set; }
    public int SitParametarHash { get; private set; }

    public int AirParametarHash { get; private set; }
    public int JumpParametarHash { get; private set; }
    public int FallParametarHash { get; private set; }

    public int AttackParametarHash { get; private set; }
    public int ComboAttackParameterHash { get; private set; }
    public int SmashParametarHash { get; private set; }
    public int DefenseParameterHash { get; private set; }

    public void Initialize()
    {
        GroundParametarHash = Animator.StringToHash(groundParametarName);
        IdleParametarHash = Animator.StringToHash(idleParametarName);
        WalkParametarHash = Animator.StringToHash(walkParametarName);
        RunParametarHash = Animator.StringToHash(runParametarName);
        RollParameratHash = Animator.StringToHash(rollParametarName);
        SitParametarHash = Animator.StringToHash(sitParametarName);

        AirParametarHash = Animator.StringToHash(airParameterName);
        JumpParametarHash = Animator.StringToHash(jumpParametarName);
        FallParametarHash = Animator.StringToHash(fallParametarName);

        AttackParametarHash = Animator.StringToHash(attackParametarName);
        ComboAttackParameterHash = Animator.StringToHash(comboattackParametarName);
        SmashParametarHash = Animator.StringToHash(smashParametarName);
        DefenseParameterHash = Animator.StringToHash(defenseParameterName);
    }
}
