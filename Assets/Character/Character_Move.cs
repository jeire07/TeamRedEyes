using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 기본 이동 속도
    private Rigidbody rb;          // Rigidbody 컴포넌트
    private Vector2 moveInput;     // 이동 입력

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트를 가져옵니다.
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
        moveSpeed = newSpeed; // 새로운 이동 속도로 업데이트
    }
     
    public void ResetMoveSpeed() //이속 리셋
    {
        moveSpeed = 5.0f; // 기본 이동 속도로 리셋
    }
}
