using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    public PlayerDeadState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(StateMachine.Player.AnimationData.IsDeadParameterHash);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameOverController gameOverController = GameObject.FindObjectOfType<GameOverController>();
        if (gameOverController != null)
        {
            gameOverController.TriggerIsDead();
        }
    }

}
