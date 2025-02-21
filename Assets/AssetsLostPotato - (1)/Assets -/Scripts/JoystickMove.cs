

using UnityEngine;

public class JoystickMove : Joystick
{
    public static Vector2 directionMove ;
    private void Update()
    {
        directionMove = direction;
    }
}
