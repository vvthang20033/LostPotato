using UnityEngine;
using UnityEngine.EventSystems;

public class PanelHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
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

        // Gán sự kiện cho joystick
        Joystick joystick = currentJoystick.GetComponentInChildren<Joystick>();
        if (joystick != null)
        {
            joystick.OnPointerDown(eventData);
        }
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        // Cập nhật vị trí joystick khi di chuyển chuột
        if (currentJoystick != null)
        {
            Joystick joystick = currentJoystick.GetComponentInChildren<Joystick>();
            if (joystick != null)
            {
                joystick.OnDrag(eventData);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Hủy joystick khi thả chuột
        if (currentJoystick != null)
        {
            Joystick joystick = currentJoystick.GetComponentInChildren<Joystick>();
            if (joystick != null)
            {
                joystick.OnPointerUp(eventData);
            }
            Destroy(currentJoystick);
        }
        JoystickMove.directionMove = Vector2.zero;
        JoystickAttack.directionAttack = Vector2.zero;
    }
}