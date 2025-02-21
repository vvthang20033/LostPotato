using UnityEngine;

public class EnemyRandomMovement : EnemyMovement
{
    
    private float range = 4.2f ; // Phạm vi di chuyển
    private Vector3 targetPosition;

    void Start()
    {
        base.Start();
        GetNewTargetPosition();
    }

    void Update()
    {
        // Lưu vị trí cũ để kiểm tra hướng
        Vector3 oldPosition = transform.position;

        // Di chuyển đến vị trí mục tiêu
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Flip theo hướng mục tiêu mới
        Flip(targetPosition.x);

        // Nếu đến nơi, chọn điểm mới
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            GetNewTargetPosition();
        }
    }


    void GetNewTargetPosition()
    {
        // Chọn vị trí mới trong phạm vi
        float randomX = Random.Range(-range, range);
        float randomZ = Random.Range(-range, range);
        targetPosition = new Vector3( randomX, transform.position.y,  randomZ);
    }
}
