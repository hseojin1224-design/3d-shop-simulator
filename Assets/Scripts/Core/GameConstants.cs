using UnityEngine;

/// <summary>
/// 게임의 모든 상수를 정의하는 클래스
/// </summary>
public static class GameConstants
{
    // ===== 돈 시스템 =====
    public const int INITIAL_MONEY = 100000; // 초기 자금: 100,000원

    // ===== 상품 정보 =====
    public const int PRODUCT_COUNT = 3; // 상품 종류

    // 상품 A (음료수)
    public const int PRODUCT_A_ID = 1;
    public const string PRODUCT_A_NAME = "음료수";
    public const int PRODUCT_A_SELLING_PRICE = 2000;
    public const int PRODUCT_A_COST_PRICE = 1000;
    public const float PRODUCT_A_PREFERENCE = 0.8f; // 높음

    // 상품 B (과자)
    public const int PRODUCT_B_ID = 2;
    public const string PRODUCT_B_NAME = "과자";
    public const int PRODUCT_B_SELLING_PRICE = 3000;
    public const int PRODUCT_B_COST_PRICE = 1500;
    public const float PRODUCT_B_PREFERENCE = 0.5f; // 중간

    // 상품 C (라면)
    public const int PRODUCT_C_ID = 3;
    public const string PRODUCT_C_NAME = "라면";
    public const int PRODUCT_C_SELLING_PRICE = 1500;
    public const int PRODUCT_C_COST_PRICE = 750;
    public const float PRODUCT_C_PREFERENCE = 0.8f; // 높음

    // ===== 상자 시스템 =====
    public const int ITEMS_PER_BOX = 10; // 상자 1개당 상품 10개

    // ===== 진열대 =====
    public const int SHELF_MAX_CAPACITY = 30; // 진열대 최대 수용 능력

    // ===== 손님 시스템 =====
    public const int MAX_CUSTOMERS = 5; // 최대 동시 손님 수
    public const float CUSTOMER_SPAWN_INTERVAL = 10f; // 손님 스폰 간격 (초)

    // 손님 구매 확률
    public const float HIGH_PREFERENCE_BUY_CHANCE = 0.6f; // 높은 선호도: 60%
    public const float MEDIUM_PREFERENCE_BUY_CHANCE = 0.4f; // 중간 선호도: 40%
    public const float LOW_PREFERENCE_BUY_CHANCE = 0.2f; // 낮은 선호도: 20%

    // ===== 플레이어 =====
    public const float PLAYER_MOVE_SPEED = 5f; // 이동 속도
    public const float PLAYER_JUMP_FORCE = 5f; // 점프 힘
    public const float PLAYER_ROTATION_SPEED = 3f; // 회전 속도

    // ===== 카메라 =====
    public const float MOUSE_SENSITIVITY = 2f; // 마우스 감도
    public const float MAX_LOOK_ANGLE = 90f; // 최대 시점 각도

    // ===== UI =====
    public const string MONEY_UI_TAG = "MoneyUI";
    public const string INVENTORY_UI_TAG = "InventoryUI";
    public const string SALES_UI_TAG = "SalesUI";

    // ===== 레이어 =====
    public const string SHELF_LAYER = "Shelf";
    public const string PRODUCT_LAYER = "Product";
    public const string CUSTOMER_LAYER = "Customer";
}
