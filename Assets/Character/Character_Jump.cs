using UnityEngine;
using UnityEngine.InputSystem;

public class Character_Jump : MonoBehaviour
{
    public float jumpForce = 5.0f; // ���� ��
    private Rigidbody rb;          // Rigidbody ������Ʈ
    private bool isGrounded;       // ���� ��� �ִ��� Ȯ��

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ�� �����ɴϴ�
    }

    void Update()
    {
        // ���� ��� �ִ��� Ȯ���ϴ� ���� (�߰� ���� �ʿ�)
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // ���� Ű�� ������ �� ����˴ϴ�
        if (context.performed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ĳ���Ͱ� ���� ��Ҵ��� Ȯ���մϴ�
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // ĳ���Ͱ� ������ ���������� Ȯ���մϴ�
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
