using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

/// <summary>
/// 손님 NPC를 생성 및 관리하는 스크립트
/// </summary>
public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab; // Customer 프리팹
    [SerializeField] private Transform[] spawnPoints; // 손님이 들어올 위치들
    [SerializeField] private float spawnInterval = GameConstants.CUSTOMER_SPAWN_INTERVAL;
    [SerializeField] private int maxCustomers = GameConstants.MAX_CUSTOMERS;

    private List<GameObject> activeCustomers = new List<GameObject>();
    private float nextSpawnTime = 0f;
    private int customerIdCounter = 0;

    private void Update()
    {
        // 활성 손님 목록 정리
        activeCustomers.RemoveAll(c => c == null);

        // 손님 수가 최대치 이하이고 시간이 지났으면 스폰
        if (activeCustomers.Count < maxCustomers && Time.time >= nextSpawnTime)
        {
            SpawnCustomer();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    /// <summary>
    /// 손님 생성
    /// </summary>
    private void SpawnCustomer()
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points set for CustomerSpawner!");
            return;
        }

        // 랜덤 스폰 위치 선택
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // 손님 생성
        GameObject customerObj = Instantiate(
            customerPrefab,
            spawnPoint.position,
            Quaternion.identity,
            transform
        );

        // 손님 초기화
        CustomerAI customerAI = customerObj.GetComponent<CustomerAI>();
        if (customerAI != null)
        {
            customerAI.Initialize(customerIdCounter++);
            activeCustomers.Add(customerObj);
            Debug.Log($"Customer spawned: #{customerAI.GetCustomerId()}");
        }
        else
        {
            Debug.LogError("CustomerAI script not found on customer prefab!");
            Destroy(customerObj);
        }
    }

    /// <summary>
    /// 현재 활성 손님 수
    /// </summary>
    public int GetActiveCustomerCount()
    {
        return activeCustomers.Count;
    }
}
