using System;

namespace Assets.Scripts.ModelsClone
{
    public class BurstShootingSystem : IShootControlSystem
    {
        private readonly Timers _timers;
        private readonly float _reloadTime;
        private readonly float _queueTime;

        private bool _canShoot;

        public BurstShootingSystem(Timers timers, float  reloadTime)
        {
            _canShoot = true;
            _timers = timers;
            _reloadTime = reloadTime;
            _queueTime = 0.2f;
        }

        public void TryShoot(Action shootAction)
        {
            if (_canShoot)
            {
                _canShoot = false;

                shootAction?.Invoke();
                _timers.AddItem(_queueTime, shootAction);
                _timers.AddItem(_queueTime * 2f, shootAction);
                _timers.AddItem(_reloadTime, () => _canShoot = true);
            }
        }
    }
}