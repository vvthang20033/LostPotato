using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score; // Điểm số hiện tại
    public static int scoreMax = 0; // Điểm số cao nhất

    void Start()
    {
        // Tải điểm số cao nhất từ PlayerPrefs khi game khởi động
        LoadScoreMax();
    }

    // Phương thức để cập nhật điểm số khi game over
    public static void UpdateScoreOnGameOver()
    {
        score = EnemySpawn.level - 1; // Cập nhật điểm số bằng level hiện tại

        // Kiểm tra và cập nhật điểm số cao nhất
        if (score > scoreMax)
        {
            scoreMax = score;
            SaveScoreMax(); // Lưu điểm số cao nhất
        }
    }

    // Lưu điểm số cao nhất vào PlayerPrefs
    private static void SaveScoreMax()
    {
        PlayerPrefs.SetInt("ScoreMax", scoreMax);
        PlayerPrefs.Save();
    }

    // Tải điểm số cao nhất từ PlayerPrefs
    private static void LoadScoreMax()
    {
        scoreMax = PlayerPrefs.GetInt("ScoreMax", 0);
    }
}