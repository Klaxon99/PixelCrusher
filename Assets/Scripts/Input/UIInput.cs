using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInput : MonoBehaviour, IInput, IMovementInputHandler, IDragHandler, IPointerClickHandler, IPointerDownHandler
{
    [SerializeField] private InputArrow _leftArrow;
    [SerializeField] private InputArrow _rightArrow;
    [SerializeField] private float _sensetivityDrag;
    [SerializeField, Range(0.05f, 0.2f)] private float _sensetivity;

    private float _startDrag;

    public float MovementAction {  get; private set; }

    public float AimAction  { get; private set; }

    public event Action ShootKeyPressed;

    public void Init()
    {
        _leftArrow.Init(this);
        _rightArrow.Init(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        float delta = eventData.position.x - _startDrag;
        float sensivity = delta / _sensetivityDrag;

        AimAction = Mathf.Clamp(sensivity, -1f, 1f) * _sensetivity;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.dragging == false)
        {
            ShootKeyPressed?.Invoke();
        }

        AimAction = 0f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startDrag = eventData.position.x;
    }

    public void SetMovementAction(float horizontalDirection)
    {
        MovementAction = horizontalDirection;
    }
}