﻿using UnityEngine;

public class TrapSpawn : MonoBehaviour
{
    public GameObject[] trapPrefabs; // Mảng chứa Prefab của các bẫy
    public float spawnRange = 3.5f; // Phạm vi spawn bẫy (từ tâm)

    void Start()
    {
        SpawnTraps(); // Spawn trap khi game bắt đầu
    }
    private void Update()
    {   
        
        if (EnemySpawn.nextLevel)
        {
            GameObject[] trap = GameObject.FindGameObjectsWithTag("TrapAttack");
            GameObject[] trap2 = GameObject.FindGameObjectsWithTag("PlayerAttack2");
           
            foreach (GameObject trapObj in trap)
            {
                RandomTransform(trapObj);
            }
            foreach (GameObject trapObj in trap2)
            {
                RandomTransform(trapObj);
            }
            EnemySpawn.nextLevel = false;
        }
    }
    public void RandomTransform(GameObject trap) // Đảm bảo đây là một phương thức
    {
        if (trap == null) return;

        Vector3 spawnPosition = GetRandomSpawnPosition();
        bool canRotate = trap.GetComponent<TrapData>()?.canRotate ?? true;
        Quaternion spawnRotation = canRotate ? GetRandomRotation() : Quaternion.identity;

        trap.transform.position = spawnPosition;
        trap.transform.rotation = spawnRotation;
    }

    // Spawn trap ngẫu nhiên
    public void SpawnTraps()
    {
        // Kiểm tra nếu không có bẫy nào được gán
        if (trapPrefabs.Length == 0)
        {
            Debug.LogWarning("Không có bẫy nào được gán!");
            return;
        }

        // Chọn ngẫu nhiên một Prefab bẫy
        int randomTrapIndex = Random.Range(0, trapPrefabs.Length);
        GameObject trapPrefab = trapPrefabs[randomTrapIndex];

        // Tạo vị trí spawn ngẫu nhiên trong phạm vi
        Vector3 spawnPosition = GetRandomSpawnPosition();

        // Kiểm tra xem trap có được phép xoay không
        bool canRotate = trapPrefab.GetComponent<TrapData>()?.canRotate ?? true;

        // Tạo hướng quay ngẫu nhiên (nếu được phép)
        Quaternion spawnRotation = canRotate ? GetRandomRotation() : Quaternion.identity;

        // Spawn bẫy tại vị trí và hướng đã chọn
        Instantiate(trapPrefab, spawnPosition, spawnRotation);

        
    }

    public Vector3 GetRandomSpawnPosition()
    {
        // Tạo vị trí ngẫu nhiên trong phạm vi
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(randomX, 0, randomZ); // Giả sử y = 0 (mặt đất)
    }

    Quaternion GetRandomRotation()
    {
        // Chọn ngẫu nhiên một trong 4 hướng (0°, 90°, 180°, 270°)
        int randomDirection = Random.Range(0, 4); // 0: trên, 1: phải, 2: dưới, 3: trái
        float angle = randomDirection * 90f; // Tính góc quay

        // Trả về rotation tương ứng
        return Quaternion.Euler(0, angle, 0);
    }
}