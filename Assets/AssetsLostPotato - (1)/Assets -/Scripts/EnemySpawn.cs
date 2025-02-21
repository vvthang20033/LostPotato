using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{


    public GameObject[] enemies; // Mảng chứa Prefab quái vật
    public int[] minLevelToSpawn; // Mảng lưu level tối thiểu để quái xuất hiện

    public Transform[] spawnPoints; // Các điểm spawn quái
    public int currentWave = 1; // Level hiện tại
    public int enemiesPerWave = 3; // Số lượng quái mỗi ván

    void Start()
    {
        StartWave();
    }

    void StartWave()
    {
        List<GameObject> validEnemies = new List<GameObject>();

        // Chỉ chọn quái có level yêu cầu <= currentWave
        for (int i = 0; i < enemies.Length; i++)
        {
            if (currentWave >= minLevelToSpawn[i])
            {
                validEnemies.Add(enemies[i]);
            }
        }

        for (int i = 0; i < enemiesPerWave; i++)
        {
            if (validEnemies.Count == 0) return; // Nếu chưa có quái hợp lệ thì dừng

            int randomIndex = Random.Range(0, validEnemies.Count); // Chọn quái hợp lệ ngẫu nhiên
            int randomSpawnIndex = Random.Range(0, spawnPoints.Length); // Chọn vị trí spawn ngẫu nhiên

            Instantiate(validEnemies[randomIndex], spawnPoints[randomSpawnIndex].position, Quaternion.identity);
        }
    }

    public void NextWave()
    {
        currentWave++;
        enemiesPerWave += 2; // Tăng số lượng quái mỗi ván
        StartWave();
    }
}


