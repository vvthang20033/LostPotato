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
            spriteRenderer.sprite = hitSprite;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(JoystickAttack.directionAttack.x, 0, JoystickAttack.directionAttack.y) * speed;
        }
    }
}
