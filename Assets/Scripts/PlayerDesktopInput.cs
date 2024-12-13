using System;
using UnityEngine;

public class PlayerDesktopInput : MonoBehaviour, IInput
{
    private const KeyCode ShootButton = KeyCode.Mouse0;
    private const KeyCode AimButton = KeyCode.Mouse1;
    private const string AimAxis = "Mouse X";
    private const string MovementAxis = "Horizontal";

    public event Action ShootKeyPressed;

    public float MovementAction { get; private set; }

    public float AimAction { get; private set; }

    private void Update()
    {
        if (Input.GetKey(AimButton))
        {
            AimAction = Input.GetAxis(AimAxis);
        }

        if (Input.GetKeyUp(AimButton))
        {
            AimAction = 0f;
        }

        if (Input.GetKeyUp(ShootButton))
        {
            ShootKeyPressed?.Invoke();
        }

        MovementAction = Input.GetAxis(MovementAxis);
    }
}