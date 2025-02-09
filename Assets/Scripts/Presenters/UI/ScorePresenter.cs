using Assets.Scripts.Models;

namespace Assets.Scripts.Presenters
{
    public class ScorePresenter : IPresenter
    {
        private readonly Score _score;
        private readonly ScoreView _scoreView;

        public ScorePresenter(Score score, ScoreView scoreView)
        {
            _score = score;
            _scoreView = scoreView;
        }

        public void Enable()
        {
            _score.CountChanged += OnScoreChanged;
        }

        public void Disable()
        {
            _score.CountChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int value)
        {
            _scoreView.SetTextValue(value.ToString());
            _scoreView.SetProgressBar((float)value / _score.MaxCount);
        }
    }
}