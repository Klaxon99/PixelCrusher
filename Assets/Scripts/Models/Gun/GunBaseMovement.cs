using UnityEngine;

namespace Assets.Scripts.Models
{
    public class GunBaseMovement : IGunMovement
    {
        public virtual SpaceOrientation Transform(SpaceOrientation spaceOrientation, ITransformActions transformActions, float deltaTime)
        {
            return new SpaceOrientation(spaceOrientation.Position, CalculateRotation(spaceOrientation.Rotation, transformActions.AimAction));
        }

        private Quaternion CalculateRotation(Quaternion currentRotation, float offset)
        {
            float staticAxis = 0f;
            Quaternion newRotation = currentRotation * Quaternion.Euler(staticAxis, offset, staticAxis);

            float dot = Vector3.Dot(newRotation * Vector3.forward, Vector3.up);
            float minCorrectDot = 0f;

            if (dot > minCorrectDot)
            {
                return newRotation;
            }

            return currentRotation;
        }
    }
}