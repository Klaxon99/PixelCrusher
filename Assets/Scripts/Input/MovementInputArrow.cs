using UnityEngine;
using UnityEngine.EventSystems;

public class MovementInputArrow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private const float StaticAction = 0f;

    [SerializeField] private float _direction;

    private IMovementInputHandler _movementInputHandler;

    public void Init(IMovementInputHandler inputHandler)
    {
        _movementInputHandler = inputHandler;
    }

    public void OnPointerDown(PointerEventData eventData) => _movementInputHandler.SetMovementAction(_direction);

    public void OnPointerUp(PointerEventData eventData) => _movementInputHandler.SetMovementAction(StaticAction);
}