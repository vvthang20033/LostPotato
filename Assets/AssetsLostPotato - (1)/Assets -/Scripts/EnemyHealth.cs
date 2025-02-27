﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private bool isGhosted = false; // Trạng thái hiện tại của enemy
    private bool isDead = false; // Đánh dấu enemy đã chết
    private Animator animator;
    private float ghostTime = 2f;
    private SpriteRenderer spriteRenderer;
    private Collider collider;
    public static bool hasKilledEnemy = false;

    void Start()
    {
        // Lấy các component cần thiết
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        collider = GetComponent<Collider>();
    }

    void Update()
    {
        // Kiểm tra nếu player bị tấn công và enemy chưa ở trạng thái ghosted hoặc chết
        if (HealthPlayer.playerHit && !isGhosted && !isDead)
        {
            Stop(); // Gọi hàm Stop() để tạm dừng enemy
        }
    }

    protected void Stop()
    {
        isGhosted = true; // Đánh dấu enemy đã dừng

        // Giảm độ trong suốt của sprite
        if (spriteRenderer != null)
        {
            Color newColor = spriteRenderer.color;
            newColor.a = 0.5f;
            spriteRenderer.color = newColor;
        }

        // Tắt tất cả script trừ script này
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            if (script != this)
            {
                script.enabled = false;
            }
        }

        // Tắt collider
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Chỉ tiếp tục hoạt động nếu enemy chưa chết
        if (!isDead)
        {
            StartCoroutine(Continue());
        }
    }

    protected IEnumerator Continue()
    {
        // Đợi ghostTime giây
        yield return new WaitForSeconds(ghostTime);

        // Khôi phục độ trong suốt của sprite
        if (spriteRenderer != null)
        {
            Color newColor = spriteRenderer.color;
            newColor.a = 1f;
            spriteRenderer.color = newColor;
        }

        isGhosted = false; // Đánh dấu enemy tiếp tục hoạt động

        // Bật lại tất cả script
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            if (script != this)
            {
                script.enabled = true;
            }
        }

        // Bật lại collider
        if (collider != null)
        {
            collider.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra nếu va chạm với đối tượng có tag "PlayerAttack2"
        if (other.CompareTag("PlayerAttack2"))
        {
            other.gameObject.tag = "Player"; // Đổi tag của đối tượng va chạm

            // Phát animation "Die" và đánh dấu enemy đã bị tiêu diệt
            if (animator != null)
            {
                animator.Play("Die");
                hasKilledEnemy = true;
            }

            isDead = true; // Đánh dấu enemy đã chết
            Stop(); // Gọi hàm Stop() để tạm dừng enemy
        }
    }
}