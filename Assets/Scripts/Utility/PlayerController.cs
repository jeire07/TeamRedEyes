using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent<Vector2> OnLookEvent;

    private void OnDisable()
    {
        OnLookEvent.RemoveAllListeners();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 mouseDelta = context.ReadValue<Vector2>();
        OnLookEvent?.Invoke(mouseDelta);
    }
}
