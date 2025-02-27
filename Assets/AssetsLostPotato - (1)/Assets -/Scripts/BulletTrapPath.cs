using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrapPath : BulletPath
{
    private Rigidbody rb;

    private void Start()
    {
        // Lấy component Rigidbody
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Thiết lập vận tốc ban đầu theo hướng transform.right
            rb.velocity = transform.right * speed;
        }
        else
        {
            Debug.LogError("Rigidbody không được tìm thấy trên đối tượng!");
        }
    }

    private void Update()
    {
        // Không cần di chuyển đạn trong Update nữa
        LimitMovement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            speed = 8;
            // Đổi tag và sprite
            gameObject.tag = "PlayerAttack2";
            if (spriteRenderer != null && hitSprite != null)
            {
                spriteRenderer.sprite = hitSprite;
            }

            // Thay đổi hướng di chuyển dựa trên JoystickAttack.directionAttack
            if (rb != null && JoystickAttack.directionAttack != null)
            {
                Vector3 direction = new Vector3(JoystickAttack.directionAttack.x, 0, JoystickAttack.directionAttack.y).normalized;
                rb.velocity = direction * speed; // Gán vận tốc mới
            }
        }
    }

    
}