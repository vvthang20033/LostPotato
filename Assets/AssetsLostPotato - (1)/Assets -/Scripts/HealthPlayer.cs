using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public static int health = 2; // Máu của người chơi
    private float speed = 8;
    public float rotateTime; // Thời gian xoay khi bị tấn công
    private float nextTimeLive = 0;
    private Animator animator;
    public static bool playerHit = false;

    // Tham chiếu đến script GameOver
    public GameOver gameOver;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (playerHit)
        {
            animator.Play("Rotate");
            transform.Rotate(0, 1000 * Time.deltaTime, 0);
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);

            if (Time.time > nextTimeLive)
            {
                playerHit = false;
                transform.rotation = Quaternion.identity;
                animator.Play("Idle");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyAttack"))
        {
            playerHit = true;
            health -= 1;
            nextTimeLive = Time.time + rotateTime;

            if (health <= 0)
            {
                GameOver();
            }
        }
    }

    // Phương thức xử lý Game Over
    private void GameOver()
    {
        gameOver.GameOverDisplay(); // Gọi phương thức GameOverDisplay
    }
}