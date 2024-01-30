using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class EnemyAnimationData
{
    [SerializeField] private string groundParameterName = "@Z_Ground";
    [SerializeField] private string idleParameterName = "Z_Idle";
    [SerializeField] private string walkParameterName = "Z_Walk";
    [SerializeField] private string runParameterName = "Z_Run";

    [SerializeField] private string attackParameterName = "@Z_Attack";
    [SerializeField] private string baseattackParameterName = "Z_BaseAttack";

    public int GroundParameterHash { get; private set; }
    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }

    public int AttackParameterHash { get; private set; }
    public int BaseAttackParameterHash { get; private set; }

    public void Initialize()
    {
        GroundParameterHash = Animator.StringToHash(groundParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        WalkParameterHash = Animator.StringToHash(walkParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);

        AttackParameterHash = Animator.StringToHash(attackParameterName);
        BaseAttackParameterHash = Animator.StringToHash(baseattackParameterName);
    }
}
