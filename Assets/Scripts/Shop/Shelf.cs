using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 진열대를 관리하는 스크립트
/// </summary>
public class Shelf : MonoBehaviour
{
    [SerializeField] private int shelfId;
    [SerializeField] private int productId; // 이 진열대에 진열되는 상품 ID
    [SerializeField] private int currentStock = 0;
    [SerializeField] private int maxCapacity = GameConstants.SHELF_MAX_CAPACITY;

    private ShelfInventory inventory;
    private bool isSoldOut = false;

    private void Start()
    {
        inventory = GetComponent<ShelfInventory>();
        if (inventory == null)
        {
            inventory = gameObject.AddComponent<ShelfInventory>();
        }
        UpdateDisplay();
    }

    /// <summary>
    /// 진열대에 상품 추가
    /// </summary>
    public bool AddStock(int quantity)
    {
        if (currentStock + quantity > maxCapacity)
        {
            Debug.LogWarning($"Shelf full! Max capacity: {maxCapacity}, Current: {currentStock}");
            return false;
        }

        currentStock += quantity;
        isSoldOut = false;
        UpdateDisplay();
        Debug.Log($"Added {quantity} items to shelf {shelfId}. Total stock: {currentStock}");
        return true;
    }

    /// <summary>
    /// 손님이 상품을 구매 (재고 감소)
    /// </summary>
    public bool BuyProduct()
    {
        if (currentStock <= 0)
        {
            isSoldOut = true;
            UpdateDisplay();
            return false;
        }

        currentStock--;
        UpdateDisplay();
        Debug.Log($"Product sold! Remaining stock on shelf {shelfId}: {currentStock}");
        return true;
    }

    /// <summary>
    /// 현재 재고량 반환
    /// </summary>
    public int GetCurrentStock()
    {
        return currentStock;
    }

    /// <summary>
    /// 진열대가 품절 상태인지 확인
    /// </summary>
    public bool IsSoldOut()
    {
        return currentStock == 0;
    }

    /// <summary>
    /// 진열대 ID 반환
    /// </summary>
    public int GetShelfId()
    {
        return shelfId;
    }

    /// <summary>
    /// 진열대의 상품 ID 반환
    /// </summary>
    public int GetProductId()
    {
        return productId;
    }

    /// <summary>
    /// 최대 용량 반환
    /// </summary>
    public int GetMaxCapacity()
    {
        return maxCapacity;
    }

    /// <summary>
    /// 진열대 디스플레이 업데이트 (UI에 반영)
    /// </summary>
    private void UpdateDisplay()
    {
        if (inventory != null)
        {
            inventory.UpdateDisplay(currentStock, isSoldOut);
        }
    }
}
