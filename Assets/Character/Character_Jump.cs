using UnityEngine;
using UnityEngine.InputSystem;

public class Character_Jump : MonoBehaviour
{
    public float jumpForce = 5.0f; // 점프 힘
    private Rigidbody rb;          // Rigidbody 컴포넌트
    private bool isGrounded;       // 땅에 닿아 있는지 확인

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트를 가져옵니다
    }

    void Update()
    {
        // 땅에 닿아 있는지 확인하는 로직 (추가 구현 필요)
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // 점프 키를 눌렀을 때 실행됩니다
        if (context.performed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 캐릭터가 땅에 닿았는지 확인합니다
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // 캐릭터가 땅에서 떨어졌는지 확인합니다
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
