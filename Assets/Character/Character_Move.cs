using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �̵� �ӵ�
    private Vector2 moveInput;     // �̵� �Է�

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 moveVector = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed;
        transform.Translate(moveVector * Time.deltaTime);
    }
}
