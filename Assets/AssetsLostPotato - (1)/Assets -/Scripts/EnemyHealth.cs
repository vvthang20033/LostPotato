using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private bool isGhosted = false; // Trạng thái hiện tại của enemy
    private Animator animator;
    private float ghostTime = 2f;
    private SpriteRenderer spriteRenderer;
    private Collider collider;
    public static bool hasKilledEnemy = false;

    void Start()
    {
        
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
        Stop();
    }

    void Update()
    {
        if (HealthPlayer.playerHit && !isGhosted)
        {
            Stop();
        }
      
    }

    protected void Stop()
    {
        isGhosted = true; // Đánh dấu enemy đã dừng
        if (spriteRenderer != null)
        {
            Color newColor = spriteRenderer.color;
            newColor.a = 0.3f;
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

        // Dừng animation (nếu có)
        if (animator != null)
        {
            animator.enabled = false;
        }
        if (collider != null)
        {
            collider.enabled = false;
        }

        StartCoroutine(Continue());
    }

    protected IEnumerator Continue()
    {   
        yield return new WaitForSeconds(ghostTime);
        if (spriteRenderer != null)
        {
            Color newColor = spriteRenderer.color;
            newColor.a = 1f;
            spriteRenderer.color = newColor;
        }
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
        if (collider != null)
        {
            collider.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack2"))
        {
            other.gameObject.tag = "Player";
            Destroy(gameObject);
            hasKilledEnemy = true;

        }
    }
}


