using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character_Rolling : MonoBehaviour
{
    public float rollForce = 5.0f;    // 구르기 힘
    public float rollDistance = 2.0f; // 구르기 거리
    private Rigidbody rb;             // Rigidbody 컴포넌트
    private Animator animator;        // Animator 컴포넌트

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트
        animator = GetComponent<Animator>(); // Animator 컴포넌트
    }

    private void OnRoll(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Roll();
        }
    }

    private void Roll()
    {
        // 애니메이션 트리거
        animator.SetTrigger("Roll");

        // 캐릭터의 현재 방향으로 구르기
        Vector3 rollDirection = transform.forward * rollForce;
        rb.AddForce(rollDirection, ForceMode.Impulse);

        // 구르기 거리에 따른 추가 이동
        StartCoroutine(RollMove(rollDirection.normalized * rollDistance));
    }

    private IEnumerator RollMove(Vector3 moveVector)
    {
        float remainingDistance = moveVector.magnitude;
        while (remainingDistance > 0)
        {
            Vector3 positionBeforeMove = rb.position;
            rb.MovePosition(rb.position + moveVector * Time.fixedDeltaTime);
            remainingDistance -= Vector3.Distance(rb.position, positionBeforeMove);
            yield return new WaitForFixedUpdate();
        }
    }
}
