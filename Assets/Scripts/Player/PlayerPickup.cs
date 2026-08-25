using UnityEngine;

/// <summary>
/// 플레이어가 상자를 집거나 놓을 때 처리하는 스크립트
/// </summary>
public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private Transform pickupPoint; // 상자를 들 위치 (손 위치)
    [SerializeField] private float pickupRange = 2f; // 상자를 집을 수 있는 거리

    private ProductBox heldBox = null;
    private Shelf targetShelf = null;

    private void Update()
    {
        HandlePickup();
        HandlePlacing();
    }

    /// <summary>
    /// E키로 상자 집기
    /// </summary>
    private void HandlePickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldBox == null)
            {
                // 근처에 상자가 있는지 확인
                ProductBox box = FindNearbyBox();
                if (box != null)
                {
                    PickupBox(box);
                }
            }
            else
            {
                // 이미 들고 있는 상자를 놓기
                PutDownBox();
            }
        }
    }

    /// <summary>
    /// R키로 상자의 상품을 진열대에 배치
    /// </summary>
    private void HandlePlacing()
    {
        if (Input.GetKeyDown(KeyCode.R) && heldBox != null)
        {
            Shelf shelf = FindNearbyShelf();
            if (shelf != null && shelf.GetProductId() == heldBox.GetProductId())
            {
                PlaceItemsOnShelf(shelf);
            }
            else
            {
                Debug.LogWarning("다른 상품의 진열대입니다!");
            }
        }
    }

    /// <summary>
    /// 근처에 있는 상자 찾기
    /// </summary>
    private ProductBox FindNearbyBox()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRange);
        foreach (Collider col in colliders)
        {
            ProductBox box = col.GetComponent<ProductBox>();
            if (box != null && !box.IsHeld())
            {
                return box;
            }
        }
        return null;
    }

    /// <summary>
    /// 근처에 있는 진열대 찾기
    /// </summary>
    private Shelf FindNearbyShelf()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRange);
        foreach (Collider col in colliders)
        {
            Shelf shelf = col.GetComponent<Shelf>();
            if (shelf != null)
            {
                return shelf;
            }
        }
        return null;
    }

    /// <summary>
    /// 상자를 집기
    /// </summary>
    private void PickupBox(ProductBox box)
    {
        heldBox = box;
        box.PickUp(pickupPoint);
        Debug.Log("상자를 집었습니다.");
    }

    /// <summary>
    /// 상자를 놓기
    /// </summary>
    private void PutDownBox()
    {
        if (heldBox != null)
        {
            heldBox.PutDown();
            heldBox = null;
            Debug.Log("상자를 놓았습니다.");
        }
    }

    /// <summary>
    /// 상자의 상품을 진열대에 배치
    /// </summary>
    private void PlaceItemsOnShelf(Shelf shelf)
    {
        if (heldBox == null) return;

        int itemsTaken = heldBox.TakeItems(GameConstants.SHELF_MAX_CAPACITY - shelf.GetCurrentStock());
        if (shelf.AddStock(itemsTaken))
        {
            Debug.Log($"{itemsTaken}개의 상품을 진열대에 배치했습니다.");
            
            // 상자가 비워졌으면 제거
            if (heldBox.GetQuantity() == 0)
            {
                Destroy(heldBox.gameObject);
                heldBox = null;
            }
        }
    }
}
