using UnityEngine;

public class TrapSpawn : MonoBehaviour
{
    public GameObject[] trapPrefabs; // Mảng chứa Prefab của các bẫy
    public float spawnRange = 4f; // Phạm vi spawn bẫy (từ tâm)

    void Start()
    {
        SpawnTrap(); // Spawn một trap khi game bắt đầu
    }

    // Spawn bẫy ngẫu nhiên
    void SpawnTrap()
    {
        if (trapPrefabs.Length == 0)
        {
            Debug.LogWarning("Không có bẫy nào được gán!");
            return;
        }

        int randomTrapIndex = Random.Range(0, trapPrefabs.Length);
        SpawnSpecificTrap(randomTrapIndex);
    }

    // Spawn bẫy chỉ định
    public void SpawnSpecificTrap(int trapIndex = 0)
    {
        if (trapIndex < 0 || trapIndex >= trapPrefabs.Length)
        {
            Debug.LogWarning("Chỉ số bẫy không hợp lệ!");
            return;
        }

        GameObject trapPrefab = trapPrefabs[trapIndex];
        Vector3 spawnPosition = GetRandomSpawnPosition();
        bool canRotate = trapPrefab.GetComponent<TrapData>()?.canRotate ?? true;
        Quaternion spawnRotation = canRotate ? GetRandomRotation() : Quaternion.identity;

        Instantiate(trapPrefab, spawnPosition, spawnRotation);
        Debug.Log($"Đã spawn bẫy {trapPrefab.name} tại vị trí {spawnPosition} với hướng {spawnRotation.eulerAngles}");
    }

    Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(randomX, 0, randomZ);
    }

    Quaternion GetRandomRotation()
    {
        int randomDirection = Random.Range(0, 4);
        float angle = randomDirection * 90f;
        return Quaternion.Euler(0, angle, 0);
    }
}