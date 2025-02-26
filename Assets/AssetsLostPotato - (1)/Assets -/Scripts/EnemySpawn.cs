using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public EnemyList enemyList; // ScriptableObject chứa danh sách enemy
    public int currentWave = 1; // Level hiện tại
    public int enemiesPerWave = 3; // Số lượng quái mỗi ván
    public float spawnRange = 4.2f; // Phạm vi spawn (giống với range trong EnemyRandomMovement)

    void Start()
    {
        StartWave();
    }

    void StartWave()
    {
        List<GameObject> validEnemies = new List<GameObject>();

        // Chỉ chọn quái có level yêu cầu <= currentWave
        for (int i = 0; i < enemyList.enemies.Length; i++)
        {
            if (currentWave >= enemyList.enemies[i].minLevelToSpawn)
            {
                validEnemies.Add(enemyList.enemies[i].prefab);
            }
        }

        // Kiểm tra nếu không có enemy hợp lệ
        if (validEnemies.Count == 0)
        {
            Debug.LogWarning("Không có enemy hợp lệ!");
            return;
        }

        // Danh sách các vị trí đã spawn
        List<Vector3> usedPositions = new List<Vector3>();

        for (int i = 0; i < enemiesPerWave; i++)
        {
            // Chọn ngẫu nhiên một enemy từ danh sách hợp lệ
            int randomEnemyIndex = Random.Range(0, validEnemies.Count);
            GameObject enemyToSpawn = validEnemies[randomEnemyIndex];

            // Tạo vị trí spawn ngẫu nhiên trong phạm vi và kiểm tra trùng lặp
            Vector3 spawnPosition = GetRandomSpawnPosition(usedPositions);

            // Spawn enemy tại vị trí đã chọn
            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);

            // Thêm vị trí vào danh sách đã sử dụng
            usedPositions.Add(spawnPosition);
        }
    }

    Vector3 GetRandomSpawnPosition(List<Vector3> usedPositions)
    {
        Vector3 spawnPosition;
        bool positionIsValid;
        int attempts = 0; // Số lần thử để tránh vòng lặp vô hạn

        do
        {
            // Tạo vị trí ngẫu nhiên trong phạm vi
            float randomX = Random.Range(-spawnRange, spawnRange);
            float randomZ = Random.Range(-spawnRange, spawnRange);
            spawnPosition = new Vector3(randomX, 0, randomZ); // Giả sử y = 0 (mặt đất)

            // Kiểm tra xem vị trí có trùng với các vị trí đã sử dụng không
            positionIsValid = true;
            foreach (Vector3 usedPosition in usedPositions)
            {
                if (Vector3.Distance(spawnPosition, usedPosition) < 1.0f) // Khoảng cách tối thiểu giữa các enemy
                {
                    positionIsValid = false;
                    break;
                }
            }

            attempts++;
            if (attempts > 100) // Tránh vòng lặp vô hạn
            {
                Debug.LogWarning("Không thể tìm vị trí spawn hợp lệ sau 100 lần thử!");
                return Vector3.zero; // Trả về vị trí mặc định nếu không tìm được
            }
        } while (!positionIsValid);

        return spawnPosition;
    }

    public void NextWave()
    {
        currentWave++;
        enemiesPerWave += 2; // Tăng số lượng quái mỗi ván
        StartWave();
    }
}