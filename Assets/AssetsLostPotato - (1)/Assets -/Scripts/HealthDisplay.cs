using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthDisplay : MonoBehaviour
{
    
    public Image[] hearts; 
  

    void Start()
    {
     
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

    public void UpdateHearts()
    {
        // Duyệt qua từng trái tim và bật/tắt dựa trên health
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < HealthPlayer.health )
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