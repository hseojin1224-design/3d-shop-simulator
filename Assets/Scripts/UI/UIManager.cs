using UnityEngine;
using TMPro;

/// <summary>
/// 게임 UI를 관리하는 매니저
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI salesText;
    [SerializeField] private TextMeshProUGUI expenseText;
    [SerializeField] private TextMeshProUGUI profitText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        UpdateMoneyUI();
    }

    private void Update()
    {
        UpdateMoneyUI();
    }

    /// <summary>
    /// 돈 UI 업데이트
    /// </summary>
    private void UpdateMoneyUI()
    {
        GameManager gm = GameManager.Instance;
        if (gm == null) return;

        if (moneyText != null)
            moneyText.text = $"현금: {gm.GetCurrentMoney():N0}원";

        if (salesText != null)
            salesText.text = $"판매: {gm.GetDailySales():N0}원";

        if (expenseText != null)
            expenseText.text = $"지출: {gm.GetDailyExpense():N0}원";

        if (profitText != null)
            profitText.text = $"순이익: {gm.GetNetProfit():N0}원";
    }
}
