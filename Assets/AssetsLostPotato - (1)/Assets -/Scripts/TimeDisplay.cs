using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        int minutes = Mathf.FloorToInt(Time.time / 60); // Lấy số phút
        int seconds = Mathf.FloorToInt(Time.time % 60); // Lấy số giây

        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
