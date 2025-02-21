using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform rectTransformJoystickBg;
    public RectTransform rectTransformJoystickHandle;
    
    public  Vector2 direction;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
        

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 delta = (eventData.position - (Vector2)rectTransformJoystickHandle.position);
        direction = delta.normalized;
        rectTransformJoystickHandle.position = eventData.position;
        rectTransformJoystickHandle.anchoredPosition = Vector2.ClampMagnitude(delta, rectTransformJoystickBg.sizeDelta.x / 2);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
        direction = Vector2.zero;
        rectTransformJoystickHandle.anchoredPosition = Vector2.zero;
    }

    
}
