using UnityEngine;

/// <summary>
/// 플레이어의 이동을 제어하는 스크립트
/// </summary>
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDirection;
    private float moveSpeed = GameConstants.PLAYER_MOVE_SPEED;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on Player!");
        }
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    /// <summary>
    /// 입력 처리
    /// </summary>
    private void HandleInput()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D
        float vertical = Input.GetAxis("Vertical");     // W/S

        // 카메라 방향 기준으로 이동 방향 설정
        Transform cameraTransform = Camera.main.transform;
        moveDirection = (cameraTransform.forward * vertical + cameraTransform.right * horizontal).normalized;
    }

    /// <summary>
    /// 이동 적용
    /// </summary>
    private void ApplyMovement()
    {
        if (rb != null)
        {
            Vector3 velocity = moveDirection * moveSpeed;
            velocity.y = rb.velocity.y; // Y축(중력)은 유지
            rb.velocity = velocity;
        }
    }
}
