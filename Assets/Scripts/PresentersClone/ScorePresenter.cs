using System;
using UnityEngine;
using Assets.Scripts.ModelsClone;

namespace Assets.Scripts.PresentersClone
{
    public class ScorePresenter
    {
        private readonly Score _model;
        private readonly ScoreView _scoreView;
        private readonly ScoreZoneView _scoreZoneView;
        private readonly EndGameScreenView _endGameScreenView;

        public ScorePresenter(Score model, ScoreView view, ScoreZoneView scoreZoneView, EndGameScreenView endGameScreenView)
        {
            _model = model ?? throw new ArgumentNullException();
            _scoreView = view ?? throw new ArgumentNullException();
            _scoreZoneView = scoreZoneView ?? throw new ArgumentNullException();
            _endGameScreenView = endGameScreenView ?? throw new ArgumentNullException();

            OnScoreChanded(_model.Count);

            Enable();
        }

        private void Enable()
        {
            _model.CountChanged += OnScoreChanded;
            _scoreZoneView.TriggerEntered += OnTriggerEnter;
        }

        private void Disable()
        {
            _model.CountChanged -= OnScoreChanded;
            _scoreZoneView.TriggerEntered -= OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out IDestructible destructible))
            {
                if (destructible is CubeGroupItem)
                {
                    _model.Add();
                }

                destructible.Destruct();
            }
        }

        private void OnScoreChanded(int count)
        {
            if (_model.Count == _model.MaxCount)
            {
                _endGameScreenView.Show();
            }

            _scoreView.SetScoreText(count);
            _scoreView.SetProgressBar((float)count / _model.MaxCount);
        }
    }
}