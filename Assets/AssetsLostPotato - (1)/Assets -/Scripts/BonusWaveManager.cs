using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusWaveManager : MonoBehaviour
{
    public static BonusWaveManager Instance;

    [Header("Buff UI")]
    public GameObject buffOption1;
    public GameObject buffOption2;
    public GameObject buff1;
    public GameObject buff2;
    public Button button1;
    public Button button2;

    [Header("Buff Data")]
    public List<DataBuff> buffDataList; // Danh sách Buff sử dụng ScriptableObject

    [Header("Trap Settings")]
    public GameObject specialTrapPrefab; // Trap chỉ định trong màn thưởng
    public Vector3 specialTrapPosition; // Vị trí spawn trap chỉ định
    private List<GameObject> originalTraps = new List<GameObject>(); // Danh sách trap cũ
    private GameObject spawnedSpecialTrap; // Trap đặc biệt xuất hiện trong màn thưởng

    private DataBuff selectedBuff1;
    private DataBuff selectedBuff2;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        buff1.SetActive(false);
        buff2.SetActive(false);
    }

    public void StartBonusWave()
    {
        Debug.Log("Màn thưởng đã bắt đầu!");
        HideAllTraps();
        SpawnSpecialTrap();
        ShowRandomBuffOptions();
    }

    void HideAllTraps()
    {
        originalTraps.Clear();
        GameObject[] traps = GameObject.FindGameObjectsWithTag("TrapAttack");
        foreach (GameObject trap in traps) { originalTraps.Add(trap); trap.SetActive(false); }
        traps = GameObject.FindGameObjectsWithTag("PlayerAttack2");
        foreach (GameObject trap in traps) { originalTraps.Add(trap); trap.SetActive(false); }
        Debug.Log($"Đã ẩn {originalTraps.Count} trap cũ.");
    }

    void SpawnSpecialTrap()
    {
        if (specialTrapPrefab != null)
        {
            spawnedSpecialTrap = Instantiate(specialTrapPrefab, specialTrapPosition, Quaternion.identity);
            Debug.Log($"Spawned trap: {specialTrapPrefab.name}");
        }
        else Debug.LogWarning("Không có trap đặc biệt!");
    }

    void ShowRandomBuffOptions()
    {
        List<DataBuff> selectedBuffs = GetRandomBuffs(2);
        selectedBuff1 = selectedBuffs[0];
        selectedBuff2 = selectedBuffs[1];

        ShowBuffOption(buffOption1, button1, selectedBuff1);
        ShowBuffOption(buffOption2, button2, selectedBuff2);

        buff1.SetActive(true);
        buff2.SetActive(true);
    }

    List<DataBuff> GetRandomBuffs(int count)
    {
        List<DataBuff> tempBuffs = new List<DataBuff>(buffDataList);
        List<DataBuff> randomBuffs = new List<DataBuff>();
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, tempBuffs.Count);
            randomBuffs.Add(tempBuffs[index]);
            tempBuffs.RemoveAt(index);
        }
        return randomBuffs;
    }

    void ShowBuffOption(GameObject buffOption, Button button, DataBuff buffData)
    {
        Image iconImage = buffOption.GetComponentInChildren<Image>();
        if (iconImage != null) iconImage.sprite = buffData.buffIcon;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => OnBuffSelected(buffData));
    }

    void OnBuffSelected(DataBuff selectedBuff)
    {
        Debug.Log($"Đã chọn buff: {selectedBuff.buffName}");
        ApplyBuff(selectedBuff);

        buff1.SetActive(false);
        buff2.SetActive(false);
        EndBonusWave();
    }

    void ApplyBuff(DataBuff buffData)
    {
        if (buffData.trapPrefab != null)
        {
            Instantiate(buffData.trapPrefab, specialTrapPosition, Quaternion.identity);
            Debug.Log($"Đã kích hoạt trap buff: {buffData.trapPrefab.name}");
        }
    }

    void EndBonusWave()
    {
        Debug.Log("Màn thưởng đã kết thúc!");
        RestoreOriginalTraps();
        if (spawnedSpecialTrap != null) Destroy(spawnedSpecialTrap);
        EnemySpawn.Instance.ContinueGameAfterBonusWave();
    }

    void RestoreOriginalTraps()
    {
        foreach (GameObject trap in originalTraps) if (trap != null) trap.SetActive(true);
        Debug.Log($"Đã khôi phục {originalTraps.Count} trap cũ.");
    }
}
