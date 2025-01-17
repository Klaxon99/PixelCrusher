using System;

namespace Assets.Scripts.Models
{
    public class GameMission : IGameMission
    {
        private readonly Score _score;

        public GameMission(Score score)
        {
            _score = score;

            _score.CountChanged += OnCountChanged;
        }

        public event Action Succeeded;

        private void OnCountChanged(int value)
        {
            if (value == _score.MaxCount)
            {
                _score.CountChanged -= OnCountChanged;

                Succeeded?.Invoke();
            }    
        }
    }
}