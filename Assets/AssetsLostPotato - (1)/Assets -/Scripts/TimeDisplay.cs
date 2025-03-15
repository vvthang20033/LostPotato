using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    private static float startTime; // Thời gian bắt đầu

    void Start()
    {
        ResetTime(); // Reset thời gian khi scene bắt đầu
    }

    void Update()
    {
        // Tính thời gian đã trôi qua kể từ lúc reset
        float elapsedTime = Time.time - startTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60); // Lấy số phút
        int seconds = Mathf.FloorToInt(elapsedTime % 60); // Lấy số giây

        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Phương thức để reset thời gian
    public static void ResetTime()
    {
        startTime = Time.time; // Đặt lại thời gian bắt đầu
    }
}