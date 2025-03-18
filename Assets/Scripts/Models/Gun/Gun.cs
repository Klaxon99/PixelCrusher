using System;

namespace Assets.Scripts.Models
{
    public class Gun
    {
        private readonly IGunMovement _movement;
        private readonly IShootControlSystem _shooter;

        public Gun(SpaceOrientation spaceOrientation, IGunMovement movement, IShootControlSystem shooter)
        {
            _movement = movement ?? throw new ArgumentNullException();
            _shooter = shooter ?? throw new ArgumentNullException();
            SpaceOrientation = spaceOrientation;
        }

        public event Action<SpaceOrientation> SpaceOrientationChanged;

        public event Action Shot;

        public SpaceOrientation SpaceOrientation {  get; private set; }

        public void Shoot(ITimer timers)
        {
            _shooter.TryShoot(() => Shot?.Invoke(), timers);
        }

        public void Transform(ITransformActions transformActions, float deltaTime)
        {
            SpaceOrientation = _movement.Transform(SpaceOrientation, transformActions, deltaTime);

            SpaceOrientationChanged?.Invoke(SpaceOrientation);
        }
    }
}