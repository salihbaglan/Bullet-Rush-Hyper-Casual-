using System;

using UnityEngine;

public class InputManager : Singleton<InputManager>
{


    [Header("Joystick")]
    public Joystick moveJoystick; // Joystick bileþeni
    public Vector3 Move; // Hareket vektörü
    private float updateInterval = 0.1f; // Güncelleme aralýðý
    private float timeSinceLastUpdate = 0f;

    private void Update()
    {
        HandleMobile();
    }


    // Mobil joystick hareketini iþle
    private void HandleMobile()
    {


        Vector2 joystickDirection = moveJoystick.Direction;

        float x = joystickDirection.x;
        float y = joystickDirection.y;
        Move = joystickDirection;


    }

}