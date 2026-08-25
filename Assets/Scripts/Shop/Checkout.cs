using UnityEngine;

/// <summary>
/// 계산대를 관리하는 스크립트
/// </summary>
public class Checkout : MonoBehaviour
{
    [SerializeField] private Shelf[] connectedShelves; // 이 계산대로 결제할 수 있는 진열대들
    [SerializeField] private float transactionRange = 2f; // 거래 가능 거리

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found!");
        }
    }

    /// <summary>
    /// 상품 판매 처리
    /// </summary>
    public bool ProcessSale(int productId, int price)
    {
        // 해당 상품의 진열대 찾기
        foreach (Shelf shelf in connectedShelves)
        {
            if (shelf.GetProductId() == productId)
            {
                // 재고 확인 및 판매
                if (shelf.BuyProduct())
                {
                    // 돈 시스템에 판매액 추가
                    gameManager.AddMoney(price);
                    Debug.Log($"Sale completed! Product ID: {productId}, Price: {price}");
                    return true;
                }
                else
                {
                    Debug.LogWarning($"Product out of stock! Product ID: {productId}");
                    return false;
                }
            }
        }

        Debug.LogError($"Product not found in connected shelves: {productId}");
        return false;
    }

    /// <summary>
    /// 진열대 연결 설정
    /// </summary>
    public void SetConnectedShelves(Shelf[] shelves)
    {
        connectedShelves = shelves;
    }

    /// <summary>
    /// 계산대가 플레이어와 상호작용 가능한 거리에 있는지 확인
    /// </summary>
    public bool IsPlayerInRange(Vector3 playerPosition)
    {
        return Vector3.Distance(transform.position, playerPosition) <= transactionRange;
    }
}
