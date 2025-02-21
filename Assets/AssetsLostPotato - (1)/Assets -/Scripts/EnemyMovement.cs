using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    public float speed;
    protected Transform transformEnemy; // Đổi sang protected để class con dùng

    protected void Start()
    {
        transformEnemy = GetComponentInChildren<Transform>();

      
    }


    void Update()
    {
        MoveToPlayer();
    }

    public void MoveToPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
        {
            // Di chuyển về phía player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            Flip(player.transform.position.x);
        }
    }

    public void Flip(float targetX)
    {
        Vector3 scale = transform.localScale;
        scale.x = (targetX < transform.position.x) ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

}
