using System;

namespace Assets.Scripts.ModelsClone
{
    public class Game
    {
        public Game(Score score)
        {
            
        }

        public event Action Paused;

        public event Action Unpaused;

        public bool IsPause { get; private set; }

        public void Stop()
        {
            IsPause = true;

            Paused?.Invoke();
        }

        public void Play()
        {
            IsPause = false;

            Unpaused?.Invoke();
        }
    }
}