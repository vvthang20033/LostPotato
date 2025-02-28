using UnityEngine;

[CreateAssetMenu(fileName = "New BuffData", menuName = "Game/BuffData")]
public class DataBuff : ScriptableObject
{
    public string buffName;
    public Sprite buffIcon; // Icon của buff
    public GameObject trapPrefab; // Trap tương ứng với buff
}
