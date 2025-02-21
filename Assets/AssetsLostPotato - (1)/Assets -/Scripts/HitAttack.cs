using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HitAttack : MonoBehaviour
{   
    public Animator animator;
    public float force = 2f;
    public float range;
    private Vector3 directionAttack;
    
    private void Start()
    {   

        animator.SetTrigger("Attack");
        directionAttack = new Vector3(JoystickAttack.directionAttack.x, 0, JoystickAttack.directionAttack.y);
    }
    public void Finish()
    {
        
        PlayerAttack.isAttacking = false;
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Hướng của enemy so với player
            Vector3 enemyDirection = (other.transform.position - transform.position).normalized;

            // Kiểm tra enemy có nằm trong phạm vi tấn công không
            float dotProduct = Vector3.Dot(directionAttack, enemyDirection);

            if (dotProduct > 0.5f) // Điều chỉnh giá trị này để thay đổi phạm vi tấn công
            {
                // Chỉ đẩy enemy nếu nó nằm trong phạm vi tấn công
                Vector3 newPosition = other.transform.position + enemyDirection * force;
                newPosition.x = Mathf.Clamp(newPosition.x, -range, range);
                newPosition.z = Mathf.Clamp(newPosition.z, -range, range);
                other.transform.position = newPosition;
            }
        }
       
    }

}
