using Assets.Scripts.Services;
using System;

namespace Assets.Scripts.Models
{
    public class GameMission : IEventService, IGameMission
    {
        private readonly Score _score;

        public GameMission(Score score)
        {
            _score = score;
        }

        public event Action Succeeded;

        public void Start() => _score.CountChanged += OnCountChanged;

        public void Stop() => _score.CountChanged -= OnCountChanged;

        private void OnCountChanged(int value)
        {
            if (value >= _score.MaxCount)
            {
                Succeeded?.Invoke();
            }    
        }
    }
}