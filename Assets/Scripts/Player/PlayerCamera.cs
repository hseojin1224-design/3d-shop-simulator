using UnityEngine;

/// <summary>
/// 플레이어 카메라를 제어하는 스크립트 (1인칭)
/// </summary>
public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = GameConstants.MOUSE_SENSITIVITY;
    [SerializeField] private float maxLookAngle = GameConstants.MAX_LOOK_ANGLE;

    private float xRotation = 0f;
    private Camera playerCamera;

    private void Start()
    {
        playerCamera = GetComponent<Camera>();
        if (playerCamera == null)
        {
            Debug.LogError("Camera not found on PlayerCamera GameObject!");
        }

        // 마우스 커서 잠금
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleMouseLook();
    }

    /// <summary>
    /// 마우스 시점 처리
    /// </summary>
    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // X축 회전 (위/아래)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Y축 회전 (좌/우)
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
