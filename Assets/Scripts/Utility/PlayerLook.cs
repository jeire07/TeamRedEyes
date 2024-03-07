using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Look")]
    [SerializeField] private float minXLook;
    [SerializeField] private float maxXLook;
    public float lookSensitivity;
    private Transform _player;
    private float _xRotation = 0f; // 추가

    [HideInInspector]
    public bool canLook = true;

    void OnEnable()
    {
        _player = transform.root;
        ToggleCursor(false);
        transform.GetComponent<PlayerController>().OnLookEvent.AddListener(RotateCamera);
    }

    public void ToggleCursor(bool toggle)
    {
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }

    private void RotateCamera(Vector2 delta)
    {
        float mouseX = delta.x * lookSensitivity / 100;
        float mouseY = delta.y * lookSensitivity / 100;

        // 플레이어만 y축을 기준으로 회전
        _player.Rotate(Vector3.up * mouseX);

        // 카메라는 x축을 기준으로만 회전
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, minXLook, maxXLook);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }
}