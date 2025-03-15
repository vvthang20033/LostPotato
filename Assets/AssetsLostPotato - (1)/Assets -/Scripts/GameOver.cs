using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI textScore; // Hiển thị điểm số hiện tại
    public TextMeshProUGUI textScoreMax; // Hiển thị điểm số cao nhất

    public void GameOverDisplay()
    {
        // Cập nhật điểm số khi game over
        ScoreManager.UpdateScoreOnGameOver();

        // Hiển thị điểm số hiện tại
        textScore.text =  ScoreManager.score.ToString();

        // Hiển thị điểm số cao nhất
        textScoreMax.text =  ScoreManager.scoreMax.ToString();

        // Hiển thị màn hình game over
        gameObject.SetActive(true);
        Time.timeScale = 0; // Dừng thời gian trong game
    }
}