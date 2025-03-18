using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GunInput : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IInput, IPointerClickHandler, IMovementInputHandler
{
    [SerializeField] private MovementInputArrow _leftArrow;
    [SerializeField] private MovementInputArrow _rightArrow;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private RectTransform _inputField;
    [SerializeField] private Camera _camera;

    public float MovementAction { get; private set; }

    public float AimAction { get; private set; }

    public event Action ShootKeyPressed;

    public void Init()
    {
        _leftArrow.Init(this);
        _rightArrow.Init(this);
        _joystick.Hide();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_inputField, eventData.pressPosition, _camera, out Vector2 pressPosition);
        _joystick.Show();
        _joystick.JoystickBackground.anchoredPosition = pressPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystick.JoystickBackground, eventData.position, _camera, out Vector2 dragPosition);
        float boundCoordinate = _joystick.JoystickBackground.sizeDelta.x / 2;
        float stickXCoordinate = Mathf.Clamp(dragPosition.x, -boundCoordinate, boundCoordinate);
        Vector2 stickPosition = new Vector2(stickXCoordinate, 0f);
        _joystick.Stick.anchoredPosition = stickPosition;

        AimAction = _joystick.Stick.anchoredPosition.x / boundCoordinate;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        AimAction = 0f;
        _joystick.Stick.anchoredPosition = Vector2.zero;
        _joystick.Hide();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ShootKeyPressed?.Invoke();
    }

    public void SetMovementAction(float value)
    {
        float absoluteBound = 1;
        MovementAction = Mathf.Clamp(value, -absoluteBound, absoluteBound);
    }
}