using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 게임의 모든 상품을 관리하는 스크립트
/// </summary>
public class ProductManager : MonoBehaviour
{
    public static ProductManager Instance { get; private set; }

    private Dictionary<int, ProductData> productDatabase = new Dictionary<int, ProductData>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        InitializeProducts();
    }

    /// <summary>
    /// 상품 데이터베이스 초기화
    /// </summary>
    private void InitializeProducts()
    {
        // 상품 A: 음료수
        productDatabase[GameConstants.PRODUCT_A_ID] = new ProductData(
            GameConstants.PRODUCT_A_ID,
            GameConstants.PRODUCT_A_NAME,
            GameConstants.PRODUCT_A_SELLING_PRICE,
            GameConstants.PRODUCT_A_COST_PRICE,
            GameConstants.PRODUCT_A_PREFERENCE
        );

        // 상품 B: 과자
        productDatabase[GameConstants.PRODUCT_B_ID] = new ProductData(
            GameConstants.PRODUCT_B_ID,
            GameConstants.PRODUCT_B_NAME,
            GameConstants.PRODUCT_B_SELLING_PRICE,
            GameConstants.PRODUCT_B_COST_PRICE,
            GameConstants.PRODUCT_B_PREFERENCE
        );

        // 상품 C: 라면
        productDatabase[GameConstants.PRODUCT_C_ID] = new ProductData(
            GameConstants.PRODUCT_C_ID,
            GameConstants.PRODUCT_C_NAME,
            GameConstants.PRODUCT_C_SELLING_PRICE,
            GameConstants.PRODUCT_C_COST_PRICE,
            GameConstants.PRODUCT_C_PREFERENCE
        );

        Debug.Log("Product database initialized with 3 products");
    }

    /// <summary>
    /// 상품 정보 조회
    /// </summary>
    public ProductData GetProductData(int productId)
    {
        if (productDatabase.TryGetValue(productId, out ProductData data))
        {
            return data;
        }
        Debug.LogWarning($"Product not found: {productId}");
        return null;
    }

    /// <summary>
    /// 모든 상품 데이터 조회
    /// </summary>
    public Dictionary<int, ProductData> GetAllProducts()
    {
        return productDatabase;
    }
}
