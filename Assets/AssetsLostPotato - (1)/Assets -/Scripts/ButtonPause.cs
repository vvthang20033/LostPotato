using UnityEngine;
using UnityEngine.UI;

public class ButtonPause : MonoBehaviour
{
    public Button buttonPause;
    public Canvas canvasPause;

    public static bool isPaused = false;

    void Start()
    {
        buttonPause.onClick.AddListener(TogglePause);
       
    }

    void TogglePause()
    {
        isPaused = !isPaused; // Đảo trạng thái pause

        if (isPaused)
        {
            canvasPause.gameObject.SetActive(true); // Hiện Pause Menu
            Time.timeScale = 0; // Dừng thời gian
        }
        
    }
}
