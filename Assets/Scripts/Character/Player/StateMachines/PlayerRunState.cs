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
        Debug.Log("�޸���");
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
        // Shift Ű�� ������ �� �ȱ� ���·� ��ȯ
        StateMachine.ChangeState(StateMachine.WalkState);
    }
}
