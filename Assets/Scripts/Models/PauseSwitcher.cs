using System;

namespace Assets.Scripts.Models
{
    public class PauseSwitcher : IPauseSwitcher
    {
        public event Action Paused;

        public event Action Unpaused;

        public bool IsPause { get; private set; } = false;

        public void Pause()
        {
            IsPause = true;

            Paused?.Invoke();
        }

        public void Unpause()
        {
            IsPause = false;

            Unpaused?.Invoke();
        }
    }
}