using UnityEngine;
using TMPro;

/// <summary>
/// 진열대의 UI를 관리하는 스크립트
/// </summary>
public class ShelfInventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stockText;
    [SerializeField] private TextMeshProUGUI soldOutText;

    /// <summary>
    /// 진열대 디스플레이 업데이트
    /// </summary>
    public void UpdateDisplay(int currentStock, bool isSoldOut)
    {
        if (stockText != null)
        {
            stockText.text = $"재고: {currentStock}";
        }

        if (soldOutText != null)
        {
            if (isSoldOut)
            {
                soldOutText.text = "품절";
                soldOutText.color = Color.red;
            }
            else
            {
                soldOutText.text = "판매중";
                soldOutText.color = Color.green;
            }
        }
    }
}
