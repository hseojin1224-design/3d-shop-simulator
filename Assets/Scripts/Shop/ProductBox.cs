using UnityEngine;

/// <summary>
/// 상품 상자를 관리하는 스크립트
/// </summary>
public class ProductBox : MonoBehaviour
{
    [SerializeField] private int productId;
    [SerializeField] private int quantity = GameConstants.ITEMS_PER_BOX; // 상자당 상품 10개
    [SerializeField] private Rigidbody rb;

    private bool isHeldByPlayer = false;
    private Transform playerHand;

    private void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 플레이어가 상자를 집는다
    /// </summary>
    public void PickUp(Transform hand)
    {
        playerHand = hand;
        isHeldByPlayer = true;
        rb.isKinematic = true; // 물리 비활성화
        Debug.Log($"Picked up product box: {productId}, Quantity: {quantity}");
    }

    /// <summary>
    /// 플레이어가 상자를 놓는다
    /// </summary>
    public void PutDown()
    {
        isHeldByPlayer = false;
        rb.isKinematic = false; // 물리 활성화
        Debug.Log($"Put down product box: {productId}");
    }

    /// <summary>
    /// 플레이어가 상자를 들고 있는지 확인
    /// </summary>
    public bool IsHeld()
    {
        return isHeldByPlayer;
    }

    /// <summary>
    /// 상자 안의 상품 개수 반환
    /// </summary>
    public int GetQuantity()
    {
        return quantity;
    }

    /// <summary>
    /// 상품 ID 반환
    /// </summary>
    public int GetProductId()
    {
        return productId;
    }

    /// <summary>
    /// 상자에서 상품 제거 (진열대에 옮길 때)
    /// </summary>
    public int TakeItems(int count)
    {
        int taken = Mathf.Min(count, quantity);
        quantity -= taken;
        Debug.Log($"Took {taken} items from box. Remaining: {quantity}");
        return taken;
    }

    private void Update()
    {
        if (isHeldByPlayer && playerHand != null)
        {
            // 플레이어 손 위치로 상자 이동
            transform.position = playerHand.position;
            transform.rotation = playerHand.rotation;
        }
    }
}
