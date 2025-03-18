using System;

namespace Assets.Scripts.Models
{
    public class GunBaseShootSystem : IShootControlSystem
    {
        private bool _canShoot = true;

        public GunBaseShootSystem(float reloadTime)
        {
            ReloadTime = reloadTime;
        }

        public float ReloadTime { get; }

        public void TryShoot(Action shootAction, ITimer timers)
        {
            if (_canShoot)
            {
                _canShoot = false;

                timers.Create(ReloadTime, () => _canShoot = true);
                shootAction?.Invoke();
            }
        }
    }
}