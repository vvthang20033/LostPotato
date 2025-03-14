using System.Collections.Generic;
using UnityEngine;

public class MonsterKillTracker : MonoBehaviour
{
    // Dictionary để lưu số lượng quái vật đã tiêu diệt theo loại
    public static Dictionary<string, int> MonstersKilledByType = new Dictionary<string, int>();

    // Hàm tăng số lượng quái vật đã tiêu diệt theo loại
    public static void AddMonstersKilled(string monsterType, int count)
    {
        if (MonstersKilledByType.ContainsKey(monsterType))
        {
            MonstersKilledByType[monsterType] += count;
        }
        else
        {
            MonstersKilledByType[monsterType] = count;
        }
    }

    // Hàm lấy số lượng quái vật đã tiêu diệt theo loại
    public static int GetMonstersKilled(string monsterType)
    {
        return MonstersKilledByType.ContainsKey(monsterType) ? MonstersKilledByType[monsterType] : 0;
    }
}