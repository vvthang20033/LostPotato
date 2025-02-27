using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusWaveManager : MonoBehaviour
{
    public static BonusWaveManager Instance;

    public GameObject buffOption1; // GameObject chứa BuffOption1
    public GameObject buffOption2; // GameObject chứa BuffOption2
    public GameObject buff1;
    public GameObject buff2;

    public Sprite[] buffIcons; // Mảng chứa các sprite icon buff
    public Button button1; // Button chọn buff 1
    public Button button2; // Button chọn buff 2

    public GameObject specialTrapPrefab; // Trap chỉ định trong màn thưởng
    public Vector3 specialTrapPosition; // Vị trí spawn trap chỉ định

    private List<GameObject> originalTraps = new List<GameObject>(); // Danh sách trap cũ
    private GameObject spawnedSpecialTrap; // Thể hiện của trap chỉ định

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
        buff1.SetActive(false);
        buff2.SetActive(false);
    }

    public void StartBonusWave()
    {
        Debug.Log("Màn thưởng đã bắt đầu!");

        // Ẩn tất cả các trap cũ
        HideAllTraps();

        // Spawn trap chỉ định
        SpawnSpecialTrap();

        // Hiển thị hai lựa chọn buff
        ShowBuffOptions();
    }

    void HideAllTraps()
    {
        // Xóa danh sách trap cũ
        originalTraps.Clear();

        // Tìm tất cả các trap với tag "TrapAttack" và thêm vào danh sách
        GameObject[] trapsAttack = GameObject.FindGameObjectsWithTag("TrapAttack");
        foreach (GameObject trap in trapsAttack)
        {
            originalTraps.Add(trap); // Lưu trap vào danh sách
            trap.SetActive(false); // Ẩn trap
        }

        // Tìm tất cả các trap với tag "PlayerAttack2" và thêm vào danh sách
        GameObject[] trapsPlayerAttack2 = GameObject.FindGameObjectsWithTag("PlayerAttack2");
        foreach (GameObject trap in trapsPlayerAttack2)
        {
            originalTraps.Add(trap); // Lưu trap vào danh sách
            trap.SetActive(false); // Ẩn trap
        }

        Debug.Log($"Đã ẩn {originalTraps.Count} trap cũ (bao gồm cả TrapAttack và PlayerAttack2).");
    }

    void SpawnSpecialTrap()
    {
        if (specialTrapPrefab != null)
        {
            // Spawn trap chỉ định tại vị trí mong muốn và lưu thể hiện
            spawnedSpecialTrap = Instantiate(specialTrapPrefab, specialTrapPosition, Quaternion.identity);
            Debug.Log($"Đã spawn trap chỉ định {specialTrapPrefab.name} tại vị trí {specialTrapPosition}");
        }
        else
        {
            Debug.LogWarning("Không có trap chỉ định được gán!");
        }
    }

    void ShowBuffOptions()
    {
        // Kích hoạt hai GameObject buff
        buff1.SetActive(true);
        buff2.SetActive(true);

        // Random icon cho từng buff
        SetRandomIcon(buffOption1);
        SetRandomIcon(buffOption2);

        // Gán sự kiện cho các button
        button1.onClick.RemoveAllListeners();
        button1.onClick.AddListener(() => OnBuffSelected(1));

        button2.onClick.RemoveAllListeners();
        button2.onClick.AddListener(() => OnBuffSelected(2));
    }

    void SetRandomIcon(GameObject buffOption)
    {
        // Lấy component Image từ GameObject buff
        Image iconImage = buffOption.GetComponentInChildren<Image>();

        if (iconImage != null && buffIcons.Length > 0)
        {
            // Chọn ngẫu nhiên một sprite từ mảng buffIcons
            int randomIndex = Random.Range(0, buffIcons.Length);
            iconImage.sprite = buffIcons[randomIndex];
            Debug.Log($"Đã đặt icon {buffIcons[randomIndex].name} cho {buffOption.name}");
        }
    }

    void OnBuffSelected(int buffIndex)
    {
        Debug.Log($"Đã chọn buff {buffIndex}");

        // Ẩn hai lựa chọn buff
        buff1.SetActive(false);
        buff2.SetActive(false);

        // Kết thúc màn thưởng và khôi phục trap cũ
        EndBonusWave();
    }

    void EndBonusWave()
    {
        Debug.Log("Màn thưởng đã kết thúc!");

        // Khôi phục lại các trap cũ
        RestoreOriginalTraps();

        // Destroy thể hiện của trap chỉ định nếu nó tồn tại
        if (spawnedSpecialTrap != null)
        {
            Destroy(spawnedSpecialTrap);
            Debug.Log("Đã destroy trap chỉ định.");
        }

        // Gọi hàm tiếp tục ván đấu từ EnemySpawn
        EnemySpawn.Instance.ContinueGameAfterBonusWave();
    }

    void RestoreOriginalTraps()
    {
        // Kích hoạt lại tất cả các trap cũ
        foreach (GameObject trap in originalTraps)
        {
            if (trap != null)
            {
                trap.SetActive(true);
            }
        }

        Debug.Log($"Đã khôi phục {originalTraps.Count} trap cũ (bao gồm cả TrapAttack và PlayerAttack2).");
    }
}