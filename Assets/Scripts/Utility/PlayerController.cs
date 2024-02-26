using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent<Vector2> OnLookEvent;
    public UnityEvent<CanvasType> OnOpenCombinedCanvasEvent;

    private void OnDisable()
    {
        OnLookEvent.RemoveAllListeners();
        OnOpenCombinedCanvasEvent.RemoveAllListeners();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 mouseDelta = context.ReadValue<Vector2>();
        OnLookEvent?.Invoke(mouseDelta);
    }

    public void OnOpenCombinedCanvas(InputAction.CallbackContext context)
    {
        if(!UIManager.Instance.GetIsOpened(CanvasType.NotFrequent))
            OnOpenCombinedCanvasEvent?.Invoke(CanvasType.Combined);
    }
}
