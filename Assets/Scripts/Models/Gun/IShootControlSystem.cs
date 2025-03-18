using System;

namespace Assets.Scripts.Models
{
    public interface IShootControlSystem
    {
        public void TryShoot(Action shootAction, ITimer timers);
    }
}