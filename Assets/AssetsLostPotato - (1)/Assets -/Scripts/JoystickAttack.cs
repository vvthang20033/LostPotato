using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickAttack : Joystick
{
    public static Vector2 directionAttack;
    private void Update()
    {
        directionAttack = direction;
    }
}
