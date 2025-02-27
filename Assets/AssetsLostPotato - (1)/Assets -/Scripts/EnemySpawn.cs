using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public EnemyList enemyList; // ScriptableObject chứa danh sách enemy
    public int currentWave = 1; // Màn hiện tại
    public int waveDifficultyPoints; // Điểm độ khó của màn hiện tại
    public float spawnRange = 4.2f; // Phạm vi spawn
    private List<GameObject> spawnedEnemies = new List<GameObject>(); // Danh sách quái đã spawn
    public static int level = 1; // Cấp độ hiện tại

    // Sự kiện khi cấp độ thay đổi
    public static System.Action OnLevelChanged;

    // Biến để kiểm tra màn thưởng
    public bool isBonusWave = false;
    public GameObject specialEnemyPrefab; // Quái thưởng (có thể điều chỉnh từ Inspector)
    public Vector3 specialEnemyPosition; // Vị trí spawn của quái thưởng
    public GameObject specialTrapPrefab; // Bẫy thưởng (có thể điều chỉnh từ Inspector)
    public Vector3 specialTrapPosition; // Vị trí spawn của bẫy thưởng
    public TrapSpawn trapSpawn; // Tham chiếu đến TrapSpawn để spawn bẫy chỉ định

    void Start()
    {
        waveDifficultyPoints = currentWave; // Điểm độ khó bằng số màn
        StartWave();
    }

    void StartWave()
    {
        // Kiểm tra nếu là màn thưởng
        if (isBonusWave)
        {
            SpawnBonusWave();
            return;
        }

        // Lọc danh sách quái có minLevelToSpawn <= currentWave và điểm <= điểm độ khó hiện tại
        List<GameObject> validEnemies = GetValidEnemiesForWave(currentWave, waveDifficultyPoints);

        // Kiểm tra nếu không có enemy hợp lệ
        if (validEnemies.Count == 0)
        {
            Debug.LogWarning("Không có enemy hợp lệ cho màn " + currentWave);
            return;
        }

        // Danh sách các vị trí đã spawn
        List<Vector3> usedPositions = new List<Vector3>();

        // Spawn quái dựa trên điểm độ khó
        while (waveDifficultyPoints > 0)
        {
            // Chọn ngẫu nhiên một enemy từ danh sách hợp lệ
            int randomEnemyIndex = Random.Range(0, validEnemies.Count);
            GameObject enemyToSpawn = validEnemies[randomEnemyIndex];

            // Lấy điểm của quái vật
            int enemyCost = enemyToSpawn.GetComponent<EnemyHealth>().GetCost();

            // Kiểm tra nếu điểm của quái vật không vượt quá điểm độ khó còn lại
            if (enemyCost <= waveDifficultyPoints)
            {
                // Tạo vị trí spawn ngẫu nhiên trong phạm vi và kiểm tra trùng lặp
                Vector3 spawnPosition = GetRandomSpawnPosition(usedPositions);

                // Spawn enemy tại vị trí đã chọn
                GameObject spawnedEnemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
                spawnedEnemies.Add(spawnedEnemy); // Thêm vào danh sách quái đã spawn

                // Trừ điểm độ khó
                waveDifficultyPoints -= enemyCost;

                // Thêm vị trí vào danh sách đã sử dụng
                usedPositions.Add(spawnPosition);
            }
        }
    }

    // Spawn màn thưởng
    void SpawnBonusWave()
    {
        // Xóa hết trap cũ
        ClearAllTraps();

        // Spawn quái thưởng tại vị trí chỉ định
        if (specialEnemyPrefab != null)
        {
            Instantiate(specialEnemyPrefab, specialEnemyPosition, Quaternion.identity);
            Debug.Log($"Đã spawn quái thưởng {specialEnemyPrefab.name} tại vị trí {specialEnemyPosition}");
        }

        // Spawn bẫy thưởng tại vị trí chỉ định
        if (specialTrapPrefab != null)
        {
            Instantiate(specialTrapPrefab, specialTrapPosition, Quaternion.identity);
            Debug.Log($"Đã spawn bẫy thưởng {specialTrapPrefab.name} tại vị trí {specialTrapPosition}");
        }

        Debug.Log("Màn thưởng đã bắt đầu!");
    }

    // Xóa hết trap cũ
    void ClearAllTraps()
    {
        GameObject[] traps = GameObject.FindGameObjectsWithTag("TrapAttack") ; // Giả sử trap có tag là "Trap"
        foreach (GameObject trap in traps)
        {
            Destroy(trap);
        }
        Debug.Log("Đã xóa hết trap cũ!");
    }

    // Lấy danh sách quái có minLevelToSpawn <= currentWave và điểm <= điểm độ khó hiện tại
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

    void Update()
    {
        // Kiểm tra nếu tất cả quái đã bị tiêu diệt
        if (spawnedEnemies.Count > 0)
        {
            spawnedEnemies.RemoveAll(enemy => enemy == null); // Loại bỏ quái đã bị tiêu diệt khỏi danh sách

            if (spawnedEnemies.Count == 0)
            {
                NextWave();
            }
        }
    }

    public void NextWave()
    {
        // Kiểm tra nếu là màn thưởng (khi currentWave bằng minLevelToSpawn của quái mới)
        foreach (var enemyData in enemyList.enemies)
        {
            if (currentWave == enemyData.minLevelToSpawn - 1) // Màn trước khi quái mới xuất hiện
            {
                isBonusWave = true;
                break;
            }
        }

        // Tăng cấp độ và màn hiện tại
        level++;
        currentWave++;

        // Cập nhật điểm độ khó
        waveDifficultyPoints = currentWave;

        // Gọi sự kiện khi cấp độ thay đổi
        OnLevelChanged?.Invoke();

        // Bắt đầu màn mới
        StartWave();
    }
}