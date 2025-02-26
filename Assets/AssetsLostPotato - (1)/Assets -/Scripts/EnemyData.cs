using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{
    public GameObject prefab; // Prefab của enemy
    public int minLevelToSpawn; // Level tối thiểu để enemy xuất hiện
}