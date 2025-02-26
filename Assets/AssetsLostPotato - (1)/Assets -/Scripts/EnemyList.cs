using UnityEngine;

[CreateAssetMenu(fileName = "EnemyList", menuName = "Enemy/EnemyList")]
public class EnemyList : ScriptableObject
{
    public EnemyData[] enemies; // Mảng chứa thông tin các enemy
}