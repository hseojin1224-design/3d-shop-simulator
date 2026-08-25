using UnityEngine;

/// <summary>
/// 창고를 관리하는 스크립트
/// </summary>
public class Warehouse : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint; // 상자를 생성할 위치
    [SerializeField] private GameObject productBoxPrefab; // ProductBox 프리팹
    [SerializeField] private int initialBoxCount = 3; // 초기 상자 개수

    private void Start()
    {
        InitializeWarehouse();
    }

    /// <summary>
    /// 창고 초기화 - 상품 상자 생성
    /// </summary>
    private void InitializeWarehouse()
    {
        // 상품별로 상자 생성
        SpawnProductBoxes(GameConstants.PRODUCT_A_ID, initialBoxCount);
        SpawnProductBoxes(GameConstants.PRODUCT_B_ID, initialBoxCount);
        SpawnProductBoxes(GameConstants.PRODUCT_C_ID, initialBoxCount);

        Debug.Log($"Warehouse initialized with {initialBoxCount * 3} product boxes");
    }

    /// <summary>
    /// 특정 상품의 상자들을 생성
    /// </summary>
    private void SpawnProductBoxes(int productId, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject boxObj = Instantiate(
                productBoxPrefab,
                spawnPoint.position + new Vector3(i * 1.5f, i * 0.1f, 0),
                Quaternion.identity,
                transform
            );

            ProductBox box = boxObj.GetComponent<ProductBox>();
            if (box == null)
            {
                box = boxObj.AddComponent<ProductBox>();
            }

            // 나중에 상품 ID 설정 (프리팹에 자동 설정되어야 함)
            Debug.Log($"Spawned product box: {productId}");
        }
    }

    /// <summary>
    /// 새로운 상품 상자 주문 (나중에 배송 시스템과 연결)
    /// </summary>
    public void OrderProductBox(int productId, int quantity)
    {
        Debug.Log($"Order placed: Product {productId}, Quantity: {quantity}");
        // TODO: 배송 시스템과 연결
    }
}
