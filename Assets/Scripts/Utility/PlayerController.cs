using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent<Vector2> OnLookEvent;
    public UnityEvent<CanvasType> OnToggleCanvasEvent;

    private void OnDisable()
    {
        OnLookEvent.RemoveAllListeners();
        OnToggleCanvasEvent.RemoveAllListeners();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 mouseDelta = context.ReadValue<Vector2>();
        OnLookEvent?.Invoke(mouseDelta);
    }

    public void OnToggleCombinedCanvas(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
            if(!UIManager.Instance.GetIsOpened(PanelType.Dialog) ||
                !UIManager.Instance.GetIsOpened(PanelType.Rest))
                OnToggleCanvasEvent?.Invoke(CanvasType.Combined);
    }
}
