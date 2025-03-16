using UnityEngine;

public class SmokeTrail : MonoBehaviour
{
    public GameObject smokePrefab; // Prefab khói
    public float spawnRate = 0.2f; // Khoảng thời gian giữa các lần spawn
    public float smokeLifetime = 1.5f; // Thời gian tồn tại của khói
    private float nextSpawnTime;
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position; // Lưu vị trí ban đầu
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            if (Vector3.Distance(transform.position, lastPosition) > 0.1f) // Kiểm tra nếu nhân vật thực sự di chuyển
            {
                GameObject smoke = Instantiate(smokePrefab, lastPosition, Quaternion.identity);
                Destroy(smoke, smokeLifetime); // Xóa khói sau một khoảng thời gian
                lastPosition = transform.position; // Cập nhật vị trí mới
                nextSpawnTime = Time.time + spawnRate;
            }
        }
    }
}
