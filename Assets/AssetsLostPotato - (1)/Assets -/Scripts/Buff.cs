using UnityEngine;

public class Buff : MonoBehaviour
{
    public enum BuffType
    {
        SpeedBoost,
        DamageBoost,
        HealthRegen
    }

    public BuffType buffType; // Loại buff
    public float duration = 5f; // Thời gian hiệu lực của buff
    public float speedBoostAmount = 2f; // Số lượng tăng tốc độ (nếu là SpeedBoost)
    public float damageBoostAmount = 1.5f; // Số lượng tăng sát thương (nếu là DamageBoost)
    public int healthRegenAmount = 10; // Số lượng hồi máu (nếu là HealthRegen)

    

   
}