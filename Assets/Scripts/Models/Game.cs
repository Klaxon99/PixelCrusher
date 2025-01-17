using System;

namespace Assets.Scripts.Models
{
    public class Game : IGame
    {
        public event Action Over;

        public void Stop()
        {
            Over?.Invoke();
        }
    }

    public interface IGame
    {
        public event Action Over;
    }
}