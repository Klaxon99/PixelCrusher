using Assets.Scripts.ModelsClone;
using UnityEngine;

public class GunDynamicMovement : IGunTransform
{
    private readonly IGunTransform _gunTransform;
    private readonly float _speed;
    private readonly float _boundCoordinate;

    public GunDynamicMovement(IGunTransform gunTransform, float speed, float boundCoordinate)
    {
        _gunTransform = gunTransform;
        _speed = speed;
        _boundCoordinate = boundCoordinate;
    }

    public SpaceOrientation Transform(SpaceOrientation spaceOrientation, ITransformActions transformActions, float deltaTime)
    {
        float offset = transformActions.MovementAction * deltaTime;

        SpaceOrientation newOrientation = new SpaceOrientation(MoveHorizontal(spaceOrientation.Position, offset), spaceOrientation.Rotation);

        return _gunTransform.Transform(newOrientation, transformActions, deltaTime);
    }

    private Vector3 MoveHorizontal(Vector3 currentPosition, float offset)
    {
        Vector3 newPosition = currentPosition + Vector3.right * offset * _speed;
        newPosition.x = Mathf.Clamp(newPosition.x, -_boundCoordinate, _boundCoordinate);

        return newPosition;
    }
}