using UnityEngine;

public class KilledEnemiesManager : MonoBehaviour
{
    // Lưu số quái vật đã giết theo loại
    public static void SaveKilledEnemies(string monsterType, int count)
    {
        PlayerPrefs.SetInt(monsterType, count);
        PlayerPrefs.Save();
    }

    // Lấy số quái vật đã giết theo loại
    public static int GetKilledEnemies(string monsterType)
    {
        return PlayerPrefs.GetInt(monsterType, 0);
    }

    // Tăng số quái vật đã giết lên 1
    public static void IncrementKilledEnemies(string monsterType)
    {
        int currentCount = GetKilledEnemies(monsterType);
        SaveKilledEnemies(monsterType, currentCount + 1);
    }

    // Reset số quái vật đã giết
    public static void ResetKilledEnemies(string monsterType)
    {
        PlayerPrefs.DeleteKey(monsterType);
        PlayerPrefs.Save();
    }
}