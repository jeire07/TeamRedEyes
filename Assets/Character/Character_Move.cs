using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 이동 속도
    private Vector2 moveInput;     // 이동 입력

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
