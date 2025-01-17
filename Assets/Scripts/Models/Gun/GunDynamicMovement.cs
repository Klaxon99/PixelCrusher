using Assets.Scripts.Models;
using UnityEngine;

public class GunDynamicMovement : GunBaseMovement
{
    private readonly float _speed;
    private readonly float _boundCoordinate;

    public GunDynamicMovement(float speed, float boundCoordinate)
    {
        _speed = speed;
        _boundCoordinate = boundCoordinate;
    }

    public override SpaceOrientation Transform(SpaceOrientation spaceOrientation, ITransformActions transformActions, float deltaTime)
    {
        SpaceOrientation baseSpaceOrientation = base.Transform(spaceOrientation, transformActions, deltaTime);

        float offset = transformActions.MovementAction * deltaTime;

        SpaceOrientation newOrientation = new SpaceOrientation(MoveHorizontal(spaceOrientation.Position, offset), baseSpaceOrientation.Rotation);

        return newOrientation;
    }

    private Vector3 MoveHorizontal(Vector3 currentPosition, float offset)
    {
        Vector3 newPosition = currentPosition + Vector3.right * offset * _speed;
        newPosition.x = Mathf.Clamp(newPosition.x, -_boundCoordinate, _boundCoordinate);

        return newPosition;
    }
}