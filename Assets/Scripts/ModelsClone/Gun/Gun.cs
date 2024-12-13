using System;

namespace Assets.Scripts.ModelsClone
{
    public class Gun
    {
        private readonly IGunTransform _movement;
        private readonly IShootControlSystem _shooter;

        public Gun(SpaceOrientation spaceOrientation, IGunTransform movement, IShootControlSystem shooter)
        {
            _movement = movement ?? throw new ArgumentNullException();
            _shooter = shooter ?? throw new ArgumentNullException();
            SpaceOrientation = spaceOrientation;
        }

        public event Action<SpaceOrientation> SpaceOrientationChanged;

        public event Action Shot;

        public SpaceOrientation SpaceOrientation {  get; private set; }

        public void Shoot()
        {
            _shooter.TryShoot(() => Shot?.Invoke());
        }

        public void Transform(ITransformActions transformActions, float deltaTime)
        {
            SpaceOrientation = _movement.Transform(SpaceOrientation, transformActions, deltaTime);

            SpaceOrientationChanged?.Invoke(SpaceOrientation);
        }
    }
}