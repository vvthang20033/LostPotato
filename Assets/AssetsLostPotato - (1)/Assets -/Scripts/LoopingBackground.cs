using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float speed; // Tốc độ di chuyển
    private RectTransform rectTransform;
    private float width;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        width = rectTransform.rect.width; // Lấy chiều rộng của ảnh
    }

    void Update()
    {
        // Di chuyển nền sang trái
        rectTransform.anchoredPosition += Vector2.left * speed * Time.deltaTime;

        // Khi ảnh đi hết bên trái, di chuyển nó về bên phải của ảnh thứ 2
        if (rectTransform.anchoredPosition.x <= -width)
        {
            rectTransform.anchoredPosition += Vector2.right * width * 2;
        }
    }
}
