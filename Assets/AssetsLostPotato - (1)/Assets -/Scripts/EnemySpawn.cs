using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn Instance;

    public EnemyList enemyList;
    public int currentWave = 0;
    public int waveDifficultyPoints;
    public float spawnRange = 3.8f;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    public static int level = 1;
    public static System.Action OnLevelChanged;
    public static bool nextLevel = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        level = 1;
        waveDifficultyPoints = currentWave;
        StartWave();
    }
    

    void StartWave()
    {
        List<GameObject> validEnemies = GetValidEnemiesForWave(currentWave, waveDifficultyPoints);

        if (validEnemies.Count == 0)
        {
            Debug.LogWarning("Không có enemy hợp lệ cho màn " + currentWave);
            return;
        }

        List<Vector3> usedPositions = new List<Vector3>();

        while (waveDifficultyPoints > 0)
        {
            int randomEnemyIndex = Random.Range(0, validEnemies.Count);
            GameObject enemyToSpawn = validEnemies[randomEnemyIndex];
            int enemyCost = enemyToSpawn.GetComponent<EnemyHealth>().GetCost();

            if (enemyCost <= waveDifficultyPoints)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition(usedPositions);
                GameObject spawnedEnemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
                spawnedEnemies.Add(spawnedEnemy);
                waveDifficultyPoints -= enemyCost;
                usedPositions.Add(spawnPosition);
            }
        }
    }

    List<GameObject> GetValidEnemiesForWave(int wave, int difficultyPoints)
    {
        List<GameObject> validEnemies = new List<GameObject>();

        foreach (var enemyData in enemyList.enemies)
        {
            int enemyCost = enemyData.prefab.GetComponent<EnemyHealth>().GetCost();
            if (wave >= enemyData.minLevelToSpawn && enemyCost <= difficultyPoints)
            {
                validEnemies.Add(enemyData.prefab);
            }
        }

        return validEnemies;
    }

    Vector3 GetRandomSpawnPosition(List<Vector3> usedPositions)
    {
        Vector3 spawnPosition;
        bool positionIsValid;
        int attempts = 0;

        do
        {
            float randomX = Random.Range(-spawnRange, spawnRange);
            float randomZ = Random.Range(-spawnRange, spawnRange);
            spawnPosition = new Vector3(randomX, 0, randomZ);

            positionIsValid = true;
            foreach (Vector3 usedPosition in usedPositions)
            {
                if (Vector3.Distance(spawnPosition, usedPosition) < 1.0f)
                {
                    positionIsValid = false;
                    break;
                }
            }

            attempts++;
            if (attempts > 100)
            {
                Debug.LogWarning("Không thể tìm vị trí spawn hợp lệ sau 100 lần thử!");
                return Vector3.zero;
            }
        } while (!positionIsValid);

        return spawnPosition;
    }

    void Update()
    {
        if (spawnedEnemies.Count > 0)
        {
            spawnedEnemies.RemoveAll(enemy => enemy == null);

            if (spawnedEnemies.Count == 0)
            {
                NextWave();
            }
        }
    }

    public void NextWave()
    {
        level++;
        currentWave++;
        waveDifficultyPoints = currentWave;
        OnLevelChanged?.Invoke();
        nextLevel = true;
        // Kiểm tra xem có phải là màn thưởng không
        if (IsBonusWave())
        {
            BonusWaveManager.Instance.StartBonusWave();
        }
        else
        {
            StartWave();
        }
    }

    bool IsBonusWave()
    {
        foreach (var enemyData in enemyList.enemies)
        {
            if ((currentWave -1)  % 3 == 0)
            {
                return true;
            }
        }
        return false;
    }

    public void ContinueGameAfterBonusWave()
    {
        Debug.Log("Tiếp tục ván đấu sau màn thưởng!");
        StartWave();
    }
}