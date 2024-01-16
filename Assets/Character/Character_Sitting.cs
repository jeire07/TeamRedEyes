using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sitting : MonoBehaviour
{
    public float sitSpeed = 2.5f; // 앉았을 때의 이동 속도
    private bool isSitting = false; // 앉아 있는지 상태를 나타내는 변수
    private CharacterMove characterMove; // CharacterMove 스크립트에 대한 참조

    private void Awake()
    {
        characterMove = GetComponent<CharacterMove>(); // CharacterMove 스크립트를 가져옵니다.
    }

    public void OnSit(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("앉았다/섰다");
            isSitting = !isSitting; // 앉기 상태를 토글합니다.
            UpdateMoveSpeed();
        }
    }

    private void UpdateMoveSpeed()
    {
        if (isSitting)
        {
            characterMove.UpdateMoveSpeed(sitSpeed); // 앉았을 때의 이동 속도로 변경
        }
        else
        {
            characterMove.ResetMoveSpeed(); // 일어났을 때 원래 속도로 복구
        }
    }
}

