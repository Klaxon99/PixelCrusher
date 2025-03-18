using UnityEngine;

namespace Assets.Scripts.Models
{
    public class GunDynamicMovement : GunBaseMovement
    {
        private readonly float _speed;
        private readonly float _boundCoordinate;

        public GunDynamicMovement(float speed)
        {
            _speed = speed;
            _boundCoordinate = 7f;
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
}