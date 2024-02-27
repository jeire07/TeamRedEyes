using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRunState : PlayerGroundState
{
    public PlayerRunState(PlayerStateMachine playerstateMachine) : base(playerstateMachine)
    {
    }

    public override void Enter()
    {
        StateMachine.MovementspeedModifier = groundData.RunSpeedModifier;
        base.Enter();
        Debug.Log("달리기");
        StartAnimation(StateMachine.Player.AnimationData.RunParameterHash);
        StateMachine.Player.Input.PlayerActions.Run.canceled += OnRunCanceled;
    }
    public override void Exit() 
    { 
        base.Exit();
        StopAnimation(StateMachine.Player.AnimationData.RunParameterHash);
        StateMachine.Player.Input.PlayerActions.Run.canceled -= OnRunCanceled;
    }

    private void OnRunCanceled(InputAction.CallbackContext context)
    {
        // Shift 키를 떼었을 때 걷기 상태로 전환
        StateMachine.ChangeState(StateMachine.WalkState);
    }
}
