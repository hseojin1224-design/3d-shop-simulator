using UnityEngine;

/// <summary>
/// 게임 전체를 관리하는 메인 매니저
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int currentMoney = GameConstants.INITIAL_MONEY;
    [SerializeField] private int dailySales = 0;
    [SerializeField] private int dailyExpense = 0;

    private void Awake()
    {
        // 싱글톤 패턴
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Debug.Log("GameManager initialized");
        Debug.Log($"Initial Money: {currentMoney}");
    }

    /// <summary>
    /// 플레이어의 현재 돈을 반환
    /// </summary>
    public int GetCurrentMoney()
    {
        return currentMoney;
    }

    /// <summary>
    /// 돈을 추가 (판매 수익)
    /// </summary>
    public void AddMoney(int amount)
    {
        currentMoney += amount;
        dailySales += amount;
        Debug.Log($"Money added: +{amount}, Total: {currentMoney}");
    }

    /// <summary>
    /// 돈을 감소 (상품 구매)
    /// </summary>
    public bool SpendMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            dailyExpense += amount;
            Debug.Log($"Money spent: -{amount}, Total: {currentMoney}");
            return true;
        }

        Debug.LogWarning($"Not enough money! Current: {currentMoney}, Required: {amount}");
        return false;
    }

    /// <summary>
    /// 일일 판매액
    /// </summary>
    public int GetDailySales()
    {
        return dailySales;
    }

    /// <summary>
    /// 일일 지출액
    /// </summary>
    public int GetDailyExpense()
    {
        return dailyExpense;
    }

    /// <summary>
    /// 순이익 계산
    /// </summary>
    public int GetNetProfit()
    {
        return dailySales - dailyExpense;
    }

    /// <summary>
    /// 일일 통계 초기화 (다음 날로 진행할 때)
    /// </summary>
    public void ResetDailyStats()
    {
        dailySales = 0;
        dailyExpense = 0;
    }
}
