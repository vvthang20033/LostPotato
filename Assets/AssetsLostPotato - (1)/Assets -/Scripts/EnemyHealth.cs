using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private bool isGhosted = false; // Trạng thái hiện tại của enemy
    private Rigidbody rb;
    private Animator animator;
    private float ghostTime = 2.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (HealthPlayer.playerHit && !isGhosted)
        {
            Stop();
        }
        else if (!HealthPlayer.playerHit && isGhosted)
        {
            Continue();
        }
    }

    private void Stop()
    {
        isGhosted = true; // Đánh dấu enemy đã dừng

        // Tắt tất cả script trừ script này
        MonoBehaviour[] scripts = GetComponentsInChildren<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            if (script != this)
            {
                script.enabled = false;
            }
        }

        // Dừng animation (nếu có)
        if (animator != null)
        {
            animator.enabled = false;
        }
    }

    private void Continue()
    {
        if(Time.time > ghostTime)
        {   
            ghostTime = Time.time + 2.5f;
            isGhosted = false; // Đánh dấu enemy tiếp tục hoạt động

            // Bật lại tất cả script
            MonoBehaviour[] scripts = GetComponentsInChildren<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                if (script != this)
                {
                    script.enabled = true;
                }
            }

            // Bật lại animation
            if (animator != null)
            {
                animator.enabled = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack2"))
        {   
            Destroy(gameObject);
        }
    }
}
