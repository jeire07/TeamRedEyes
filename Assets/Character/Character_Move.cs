using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �⺻ �̵� �ӵ�
    private Rigidbody rb;          // Rigidbody ������Ʈ
    private Vector2 moveInput;     // �̵� �Է�

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ�� �����ɴϴ�.
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 moveVector = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed;
        rb.MovePosition(rb.position + moveVector * Time.fixedDeltaTime);
    }
    public void UpdateMoveSpeed(float newSpeed)
    {
        moveSpeed = newSpeed; // ���ο� �̵� �ӵ��� ������Ʈ
    }
     
    public void ResetMoveSpeed() //�̼� ����
    {
        moveSpeed = 5.0f; // �⺻ �̵� �ӵ��� ����
    }
}
