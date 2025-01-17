using UnityEngine;
using UnityEngine.EventSystems;

public class InputArrow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private const float StaticDirection = 0f;

    [SerializeField] private float _direction;

    private IMovementInputHandler _inputHandler;

    public void Init(IMovementInputHandler movementInputHandler)
    {
        _inputHandler = movementInputHandler;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _inputHandler.SetMovementAction(_direction);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _inputHandler.SetMovementAction(StaticDirection);
    }
}