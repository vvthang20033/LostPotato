using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        // Cập nhật UI ngay khi bắt đầu
        UpdateLevelDisplay();
    }

    void OnEnable()
    {
        // Đăng ký sự kiện khi cấp độ thay đổi
        EnemySpawn.OnLevelChanged += UpdateLevelDisplay;
    }

    void OnDisable()
    {
        // Hủy đăng ký sự kiện khi đối tượng bị vô hiệu hóa
        EnemySpawn.OnLevelChanged -= UpdateLevelDisplay;
    }

    void UpdateLevelDisplay()
    {
        // Cập nhật text với cấp độ hiện tại
        text.text = "Cấp độ" + EnemySpawn.level;
    }
}