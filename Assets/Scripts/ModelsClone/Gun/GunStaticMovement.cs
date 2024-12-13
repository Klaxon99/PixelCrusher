using Assets.Scripts.ModelsClone;
using UnityEngine;

public class GunStaticMovement : IGunTransform
{
    public SpaceOrientation Transform(SpaceOrientation spaceOrientation, ITransformActions transformActions, float deltaTime)
    {
        return new SpaceOrientation(spaceOrientation.Position, CalculateRotation(spaceOrientation.Rotation, transformActions.AimAction));
    }

    private Quaternion CalculateRotation(Quaternion rotation, float offset)
    {
        Quaternion newRotation = rotation * Quaternion.Euler(0, offset, 0);

        float dot = Vector3.Dot(newRotation * Vector3.forward, Vector3.up);

        if (dot > 0f)
        {
            return newRotation;
        }

        return rotation;
    }
}