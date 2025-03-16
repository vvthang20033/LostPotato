using UnityEngine;
using UnityEngine.EventSystems;

public class PanelHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject joystickPrefab; // Prefab của joystick
    private GameObject currentJoystick; // Joystick hiện tại

    public void OnPointerDown(PointerEventData eventData)
    {
        // Tạo joystick tại vị trí bấm chuột
        currentJoystick = Instantiate(joystickPrefab, transform);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform as RectTransform,
            eventData.position,
            null,
            out Vector2 localPoint
        );
        currentJoystick.GetComponent<RectTransform>().anchoredPosition = localPoint;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Hủy joystick khi thả chuột
        if (currentJoystick != null)
        {
            Destroy(currentJoystick);
        }
    }
}