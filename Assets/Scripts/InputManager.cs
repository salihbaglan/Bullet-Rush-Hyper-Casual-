using System;

using UnityEngine;

public class InputManager : Singleton<InputManager>
{


    [Header("Joystick")]
    public Joystick moveJoystick; // Joystick bile�eni
    public Vector3 Move; // Hareket vekt�r�
    private float updateInterval = 0.1f; // G�ncelleme aral���
    private float timeSinceLastUpdate = 0f;

    private void Update()
    {
        HandleMobile();
    }


    // Mobil joystick hareketini i�le
    private void HandleMobile()
    {


        Vector2 joystickDirection = moveJoystick.Direction;

        float x = joystickDirection.x;
        float y = joystickDirection.y;
        Move = joystickDirection;


    }

}