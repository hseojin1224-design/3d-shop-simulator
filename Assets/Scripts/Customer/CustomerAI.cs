using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 손님 NPC의 AI를 제어하는 스크립트
/// </summary>
public class CustomerAI : MonoBehaviour
{
    [SerializeField] private int customerId;
    [SerializeField] private float detectionRange = 10f; // 상품 감지 범위
    [SerializeField] private float moveSpeed = 3f;

    private NavMeshAgent navMeshAgent;
    private Shelf targetShelf = null;
    private int desiredProductId = -1;
    private bool hasSelectedProduct = false;
    private Checkout targetCheckout = null;

    private enum CustomerState
    {
        Idle,
        Browsing,
        SearchingProduct,
        MovingToShelf,
        BuyingProduct,
        MovingToCheckout,
        PayingAndLeaving
    }

    private CustomerState currentState = CustomerState.Browsing;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
        }
        navMeshAgent.speed = moveSpeed;
    }

    /// <summary>
    /// 손님 초기화
    /// </summary>
    public void Initialize(int id)
    {
        customerId = id;
        SelectRandomProduct();
    }

    /// <summary>
    /// 손님 ID 반환
    /// </summary>
    public int GetCustomerId()
    {
        return customerId;
    }

    private void Update()
    {
        switch (currentState)
        {
            case CustomerState.Browsing:
                BrowseShop();
                break;
            case CustomerState.SearchingProduct:
                SearchForProduct();
                break;
            case CustomerState.MovingToShelf:
                MoveToShelf();
                break;
            case CustomerState.BuyingProduct:
                BuyProduct();
                break;
            case CustomerState.MovingToCheckout:
                MoveToCheckout();
                break;
            case CustomerState.PayingAndLeaving:
                LeaveShop();
                break;
        }
    }

    /// <summary>
    /// 상점을 돌아다니는 상태
    /// </summary>
    private void BrowseShop()
    {
        // 일정 시간 후 상품 찾기 시작
        if (Random.value > 0.95f)
        {
            currentState = CustomerState.SearchingProduct;
        }
    }

    /// <summary>
    /// 원하는 상품 찾기
    /// </summary>
    private void SearchForProduct()
    {
        Shelf[] allShelves = FindObjectsOfType<Shelf>();
        foreach (Shelf shelf in allShelves)
        {
            if (shelf.GetProductId() == desiredProductId && !shelf.IsSoldOut())
            {
                targetShelf = shelf;
                currentState = CustomerState.MovingToShelf;
                return;
            }
        }

        // 상품을 찾지 못하면 나가기
        currentState = CustomerState.PayingAndLeaving;
    }

    /// <summary>
    /// 진열대로 이동
    /// </summary>
    private void MoveToShelf()
    {
        if (targetShelf == null)
        {
            currentState = CustomerState.PayingAndLeaving;
            return;
        }

        navMeshAgent.SetDestination(targetShelf.transform.position);

        if (Vector3.Distance(transform.position, targetShelf.transform.position) < 1f)
        {
            currentState = CustomerState.BuyingProduct;
        }
    }

    /// <summary>
    /// 상품 구매
    /// </summary>
    private void BuyProduct()
    {
        if (targetShelf != null && targetShelf.BuyProduct())
        {
            // 구매 성공
            Debug.Log($"Customer #{customerId} bought product {desiredProductId}");
            currentState = CustomerState.MovingToCheckout;
        }
        else
        {
            // 품절
            currentState = CustomerState.PayingAndLeaving;
        }
    }

    /// <summary>
    /// 계산대로 이동
    /// </summary>
    private void MoveToCheckout()
    {
        Checkout checkout = FindObjectOfType<Checkout>();
        if (checkout == null)
        {
            currentState = CustomerState.PayingAndLeaving;
            return;
        }

        targetCheckout = checkout;
        navMeshAgent.SetDestination(checkout.transform.position);

        if (Vector3.Distance(transform.position, checkout.transform.position) < 1f)
        {
            currentState = CustomerState.PayingAndLeaving;
        }
    }

    /// <summary>
    /// 계산 및 퇴장
    /// </summary>
    private void LeaveShop()
    {
        // 결제 처리
        if (targetCheckout != null && hasSelectedProduct)
        {
            targetCheckout.ProcessSale(desiredProductId, GetProductPrice(desiredProductId));
        }

        // 상점 나가기 (오브젝트 제거)
        Destroy(gameObject);
    }

    /// <summary>
    /// 랜덤으로 상품 선택
    /// </summary>
    private void SelectRandomProduct()
    {
        int random = Random.Range(1, GameConstants.PRODUCT_COUNT + 1);
        desiredProductId = random;
        hasSelectedProduct = true;
        Debug.Log($"Customer #{customerId} wants product {desiredProductId}");
    }

    /// <summary>
    /// 상품 가격 반환
    /// </summary>
    private int GetProductPrice(int productId)
    {
        return productId switch
        {
            GameConstants.PRODUCT_A_ID => GameConstants.PRODUCT_A_SELLING_PRICE,
            GameConstants.PRODUCT_B_ID => GameConstants.PRODUCT_B_SELLING_PRICE,
            GameConstants.PRODUCT_C_ID => GameConstants.PRODUCT_C_SELLING_PRICE,
            _ => 0
        };
    }
}
