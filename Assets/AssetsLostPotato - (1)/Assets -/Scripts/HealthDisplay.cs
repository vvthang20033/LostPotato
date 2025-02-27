using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Sử dụng nếu bạn dùng UI Canvas

public class HealthDisplay : MonoBehaviour
{
    public HealthPlayer healthPlayer; // Tham chiếu đến script HealthPlayer
    public Image[] hearts; // Mảng chứa các hình ảnh trái tim (UI Canvas)
    // Hoặc sử dụng SpriteRenderer nếu bạn dùng Sprite trong game world:
    // public SpriteRenderer[] hearts;

    void Start()
    {
        // Khởi tạo mảng hearts nếu chưa được gán trong Inspector
        if (hearts == null || hearts.Length == 0)
        {
            hearts = new Image[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                hearts[i] = transform.GetChild(i).GetComponent<Image>();
            }
        }

        // Cập nhật trái tim ngay khi bắt đầu
        UpdateHearts();
    }

    void Update()
    {
        // Cập nhật trái tim mỗi frame (hoặc có thể dùng sự kiện để tối ưu)
        UpdateHearts();
    }

    void UpdateHearts()
    {
        // Duyệt qua từng trái tim và bật/tắt dựa trên health
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < healthPlayer.health)
            {
                hearts[i].enabled = true; // Bật trái tim nếu còn máu
            }
            else
            {
                hearts[i].enabled = false; // Tắt trái tim nếu hết máu
            }
        }
    }
}