using UnityEngine;

/// <summary>
/// 상품 데이터 (판매 기록 등)
/// </summary>
public class Product : MonoBehaviour
{
    private ProductData productData;

    public void Initialize(ProductData data)
    {
        productData = data;
    }

    public ProductData GetProductData()
    {
        return productData;
    }
}
