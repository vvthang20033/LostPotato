﻿using TMPro;
using UnityEngine;

public class ButtonLock : MonoBehaviour
{
    public TextMeshProUGUI textScorePlayer; // Hiển thị điểm hiện tại
    public TextMeshProUGUI textScoreUnlock; // Hiển thị điểm cần để mở khóa
    public int scoreUnlock; // Điểm cần để mở khóa
    public GameObject canvasScoreUnlock; // Canvas hiển thị thông báo
    public GameObject costumeObject; // Đối tượng trang phục sẽ được mở khóa


    private bool isUnlocked = false; // Trạng thái mở khóa

    private void Start()
    {
        // Kiểm tra điều kiện mở khóa ngay khi bắt đầu
        CheckAndUnlock();
    }

    private void Update()
    {
        // Liên tục kiểm tra điều kiện mở khóa nếu chưa mở
        if (!isUnlocked)
        {
            CheckAndUnlock();
        }
    }

    // Phương thức được gọi khi click vào ButtonLock
    private void OnMouseDown()
    {
        // Chỉ kiểm tra thủ công nếu chưa mở khóa
        if (!isUnlocked)
        {
            ClickOutsideHandler.isClickOnButtonLock = true;
            ShowUnlockCondition();
        }
    }

    private void CheckAndUnlock()
    {
        // Tải điểm số hiện tại
        ScoreManager.LoadScore();

        // Kiểm tra nếu đủ điểm để mở khóa
        if (ScoreManager.totalScore >= scoreUnlock)
        {
            UnlockCostume(); // Mở khóa
            isUnlocked = true; // Đánh dấu đã mở khóa
        }
    }

    private void ShowUnlockCondition()
    {
        // Hiển thị thông báo điều kiện mở khóa
        canvasScoreUnlock.SetActive(true);
        textScorePlayer.text = ScoreManager.totalScore.ToString();
        textScoreUnlock.text = scoreUnlock.ToString();
    }

    private void UnlockCostume()
    {
        // Ẩn lock và hiển thị trang phục
        if (gameObject != null)
        {
            gameObject.SetActive(false); // Ẩn lock
        }

        if (costumeObject != null)
        {
            costumeObject.SetActive(true); // Hiển thị trang phục
        }

        // Ẩn canvas thông báo (nếu đang hiển thị)
        canvasScoreUnlock.SetActive(false);
    }
}