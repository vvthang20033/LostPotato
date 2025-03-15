using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonRestart : MonoBehaviour
{
    public Button buttonRestart;
    public HealthDisplay healthDisplay;
    // Start is called before the first frame update
    void Start()
    {
        buttonRestart.onClick.AddListener(ToggleRestart);
    }
    public void Reset()
    {
        EnemySpawn.level = 1;
        HealthPlayer.health = 2;
        healthDisplay.UpdateHearts(); // Cập nhật trái tim ngay lập tức
        TimeDisplay.ResetTime();

    }
    private void ToggleRestart()
    {
        Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
