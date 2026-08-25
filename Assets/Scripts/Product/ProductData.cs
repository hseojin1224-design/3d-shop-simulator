using UnityEngine;

/// <summary>
/// 상품 데이터를 정의하는 클래스
/// </summary>
[System.Serializable]
public class ProductData
{
    public int productId;
    public string productName;
    public int sellingPrice;
    public int costPrice;
    public float customerPreference; // 0~1
    public Sprite productIcon; // UI에서 사용할 아이콘

    public ProductData(int id, string name, int selling, int cost, float preference)
    {
        productId = id;
        productName = name;
        sellingPrice = selling;
        costPrice = cost;
        customerPreference = preference;
    }

    public int GetProfit()
    {
        return sellingPrice - costPrice;
    }
}
