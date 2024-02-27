using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [Header("Look Settings")]
    [SerializeField] private float minXLook = -90f;
    [SerializeField] private float maxXLook = 90f;
    [SerializeField] private float lookSensitivity = 100f;
    [SerializeField] private InputAction lookAction; // 마우스 움직임에 대한 Input Action

    private Transform playerBody; // This will be the transform that should rotate around Y axis

    [HideInInspector]
    public bool canLook = true;

    private void OnEnable()
    {
        playerBody = transform.root;
        ToggleCursor(false);
        lookAction.Enable();
    }

    private void OnDisable()
    {
        lookAction.Disable();
    }

    void Update()
    {
        if (canLook)
        {
            RotateCameraBasedOnInput();
        }
    }

    public void ToggleCursor(bool toggle)
    {
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = toggle;
        canLook = !toggle;
    }

    private void RotateCameraBasedOnInput()
    {
        Vector2 lookInput = lookAction.ReadValue<Vector2>(); // 새로운 Input System을 사용하여 입력값을 읽음
        float mouseX = lookInput.x * lookSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * lookSensitivity * Time.deltaTime;

        // Player rotation around Y axis
        playerBody.Rotate(Vector3.up * mouseX);

        // Camera rotation around X axis
        float currentXRotation = transform.localEulerAngles.x;
        float rotationAmountX = currentXRotation - mouseY;
        if (rotationAmountX > 180f) rotationAmountX -= 360f; // Adjust for Unity's 360 degree representation

        rotationAmountX = Mathf.Clamp(rotationAmountX, minXLook, maxXLook);

        transform.localEulerAngles = new Vector3(rotationAmountX, transform.localEulerAngles.y, 0);
    }
}
