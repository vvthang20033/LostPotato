using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPath : EnemyMovement
{
    Vector3 direction;
    public float range;
    public SpriteRenderer spriteRenderer;
    public Sprite hitSprite;


    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        direction = (player.transform.position - transform.position).normalized;
    }
    private void Update()
    {
        if (direction != Vector3.zero)
        {
            transform.position += direction * speed * Time.deltaTime;

        }
        LimitMovement();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            spriteRenderer.sprite = hitSprite;
            direction = new Vector3(JoystickAttack.directionAttack.x, 0, JoystickAttack.directionAttack.y).normalized;
            gameObject.tag = "PlayerAttack2";
            
        }
    }
    protected void LimitMovement()
    {
        if (Mathf.Abs(transform.position.x) > range || Mathf.Abs(transform.position.z) > range)
        {
            Destroy(gameObject);
        }
    }
}

