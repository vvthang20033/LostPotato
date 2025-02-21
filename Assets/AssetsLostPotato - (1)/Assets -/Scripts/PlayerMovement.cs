using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public ParticleSystem particleSystem;
    public float speed;
    public Animator playerAnimator;
    public SpriteRenderer playerSpriteRenderer;
    public Vector3 vectoroffset;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    private void Update()
    {
        
        Vector2 move = JoystickMove.directionMove;
        Vector3 velocity = new Vector3(move.x, 0, move.y) * speed;

     
        if ((rb.position.x <= minBounds.x && velocity.x < 0) || (rb.position.x >= maxBounds.x && velocity.x > 0))
        {
            velocity.x = 0; 
        }

        
        if ((rb.position.z <= minBounds.y && velocity.z < 0) || (rb.position.z >= maxBounds.y && velocity.z > 0))
        {
            velocity.z = 0; 
        }

        // Áp dụng vận tốc
        rb.velocity = velocity;

        // Xử lý animation và hiệu ứng hạt
        if (move.magnitude > 0)
        {
            playerAnimator.SetBool("isRunning", true);
            particleSystem.Play();
            if(move.x > 0)
            {
                transform.localScale = new Vector3 (1,1,1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
            particleSystem.Stop();
        }
    }
}
