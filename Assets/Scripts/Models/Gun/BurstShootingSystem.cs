using System;

namespace Assets.Scripts.Models
{
    public class BurstShootingSystem : IShootControlSystem
    {
        private float _queueTime;
        private int _queueLength;
        private bool _canShoot;

        public BurstShootingSystem(float reloadTime, int queueLength)
        {
            _canShoot = true;
            ReloadTime = reloadTime;
            _queueTime = 0.2f;
            _queueLength = queueLength;
        }

        public float ReloadTime { get; }

        public void TryShoot(Action shootAction, ITimer timers)
        {
            if (_canShoot)
            {
                _canShoot = false;

                for (int i = 0; i < _queueLength; i++)
                {
                    timers.Create(i * _queueTime, shootAction);
                }

                timers.Create(ReloadTime, () => _canShoot = true);
            }
        }
    }
}