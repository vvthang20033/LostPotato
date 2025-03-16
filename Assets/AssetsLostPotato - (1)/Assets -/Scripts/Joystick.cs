using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform rectTransformJoystickBg; // Background của joystick
    public RectTransform rectTransformJoystickHandle; // Handle của joystick

    public Vector2 direction; // Hướng di chuyển của joystick

    private bool isActive = false; // Trạng thái hoạt động của joystick

    public void OnPointerDown(PointerEventData eventData)
    {
        isActive = true;
        OnDrag(eventData); // Cập nhật vị trí handle ngay khi bấm chuột
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isActive) return;

        // Tính toán vị trí tương đối của chuột so với background
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransformJoystickBg,
            eventData.position,
            null,
            out Vector2 localPoint
        );

        // Di chuyển handle trong phạm vi background
        rectTransformJoystickHandle.anchoredPosition = Vector2.ClampMagnitude(
            localPoint,
            rectTransformJoystickBg.sizeDelta.x / 2
        );

        // Tính toán hướng di chuyển
        direction = localPoint.normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isActive = false;
        direction = Vector2.zero; // Reset hướng di chuyển khi thả chuột
        rectTransformJoystickHandle.anchoredPosition = Vector2.zero; // Đưa handle về vị trí ban đầu
    }
}