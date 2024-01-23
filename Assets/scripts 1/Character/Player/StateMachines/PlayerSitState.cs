using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSitState : PlayerGroundState
{
    public PlayerSitState(PlayerStateMachine playerstateMachine) : base(playerstateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(StateMachine.Player.AnimationData.SitParameterHash);
        Debug.Log("¾É¾Ò´Ù");
    }
    public override void Exit() 
    { 
        base.Exit();
        StopAnimation(StateMachine.Player.AnimationData.SitParameterHash);
    }

}
