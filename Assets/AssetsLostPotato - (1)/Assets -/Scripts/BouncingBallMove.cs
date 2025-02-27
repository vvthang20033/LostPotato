using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BouncingBallMove : MonoBehaviour
{
    public SpriteRenderer spriteRendererBouncing;
    public Sprite ballWhite;
    public Sprite ballGreen;
    public Sprite ballWhiteBlood;
    public Sprite ballGreenBlood;
    private Rigidbody rb;
    private float range = 4.4f;
    private Vector3 direction;
    private float speed = 5;

    private void Start()
    {
        float X = Random.Range(-1f, 1f);
        float Z = Random.Range(-1f, 1f);
        direction = new Vector3(X, 0, Z);
    }
    // Update is called once per frame
    void Update()
    {

        // Kiểm tra va chạm với tường
        if (Mathf.Abs(transform.position.x) >= range)
        {
            ResetBall();
            direction.x = -direction.x; // Đảo hướng X khi chạm tường X
            direction.z += Random.Range(-0.6f, 0.6f); // Tạo sự lệch hướng
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -range + 0.1f, range - 0.1f), transform.position.y, transform.position.z);
        }
        if (Mathf.Abs(transform.position.z) >= range)
        {
            ResetBall();
            direction.z = -direction.z; // Đảo hướng Z khi chạm tường Z
            direction.x += Random.Range(-0.6f, 0.6f); // Tạo sự lệch hướng
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -range + 0.1f, range - 0.1f));
        }


        // Chuẩn hóa lại hướng để tránh tốc độ thay đổi thất thường
        direction = direction.normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            speed = 8;
            gameObject.tag = "PlayerAttack2";

            if (spriteRendererBouncing.sprite.name == ballGreen.name)
            {
                spriteRendererBouncing.sprite = ballWhite;
            }
            else if (spriteRendererBouncing.sprite.name == ballGreenBlood.name)
            {
                spriteRendererBouncing.sprite = ballWhiteBlood;
            }
            Vector3 newDirection = new Vector3(JoystickAttack.directionAttack.x, 0, JoystickAttack.directionAttack.y).normalized;
            if (newDirection != Vector3.zero)
            {
                direction = newDirection.normalized;
            }
        }
        if (other.CompareTag("Enemy"))
        {
            if (EnemyHealth.hasKilledEnemy == true && spriteRendererBouncing.sprite == ballWhite)
            {
                spriteRendererBouncing.sprite = ballGreenBlood;
            }
        }

    }
    private void ResetBall()
    {
        gameObject.tag = "Player";
        speed = 5;
        if (spriteRendererBouncing.sprite == ballWhite)
        {
            spriteRendererBouncing.sprite = ballGreen;
        }
        else if (spriteRendererBouncing.sprite == ballWhiteBlood)
        {
            spriteRendererBouncing.sprite = ballGreenBlood;
        }

    }

}
