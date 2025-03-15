using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score; // Điểm số hiện tại
    public static int scoreMax; // Điểm số cao nhất
    public static int totalScore; // Tổng điểm tích lũy

    void Start()
    {
        LoadScore();
    }

    public static void UpdateScoreOnGameOver()
    {
        score = EnemySpawn.level - 1; // Cập nhật điểm số bằng level hiện tại

        // Cộng điểm của lần chơi này vào tổng điểm
        totalScore += score;
        PlayerPrefs.SetInt("TotalScore", totalScore);

        // Kiểm tra và cập nhật điểm số cao nhất
        if (score > scoreMax)
        {
            scoreMax = score;
            PlayerPrefs.SetInt("ScoreMax", scoreMax);
        }

        // Lưu dữ liệu
        PlayerPrefs.Save();
    }
    public static void LoadScore()
    {
        scoreMax = PlayerPrefs.GetInt("ScoreMax", 0);
        totalScore = PlayerPrefs.GetInt("TotalScore", 0);
    }
}