using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character_Rolling : MonoBehaviour
{
    public float rollForce = 5.0f;    // ������ ��
    public float rollDistance = 2.0f; // ������ �Ÿ�
    private Rigidbody rb;             // Rigidbody ������Ʈ
    private Animator animator;        // Animator ������Ʈ

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ
        animator = GetComponent<Animator>(); // Animator ������Ʈ
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
        // �ִϸ��̼� Ʈ����
        animator.SetTrigger("Roll");

        // ĳ������ ���� �������� ������
        Vector3 rollDirection = transform.forward * rollForce;
        rb.AddForce(rollDirection, ForceMode.Impulse);

        // ������ �Ÿ��� ���� �߰� �̵�
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
