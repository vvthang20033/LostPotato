using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrapPath : BulletPath
{
   
   

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
        LimitMovement();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            gameObject.tag = "PlayerAttack2";
            spriteRenderer.sprite = hitSprite;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null && JoystickAttack.directionAttack != null)
            {
                Vector3 direction = new Vector3(JoystickAttack.directionAttack.x, 0, JoystickAttack.directionAttack.y).normalized;
                rb.velocity = direction * speed;
            }
        }
    }
}
