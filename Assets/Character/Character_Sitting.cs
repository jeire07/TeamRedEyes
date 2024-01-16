using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sitting : MonoBehaviour
{
    public float sitSpeed = 2.5f; // �ɾ��� ���� �̵� �ӵ�
    private bool isSitting = false; // �ɾ� �ִ��� ���¸� ��Ÿ���� ����
    private CharacterMove characterMove; // CharacterMove ��ũ��Ʈ�� ���� ����

    private void Awake()
    {
        characterMove = GetComponent<CharacterMove>(); // CharacterMove ��ũ��Ʈ�� �����ɴϴ�.
    }

    public void OnSit(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("�ɾҴ�/����");
            isSitting = !isSitting; // �ɱ� ���¸� ����մϴ�.
            UpdateMoveSpeed();
        }
    }

    private void UpdateMoveSpeed()
    {
        if (isSitting)
        {
            characterMove.UpdateMoveSpeed(sitSpeed); // �ɾ��� ���� �̵� �ӵ��� ����
        }
        else
        {
            characterMove.ResetMoveSpeed(); // �Ͼ�� �� ���� �ӵ��� ����
        }
    }
}

