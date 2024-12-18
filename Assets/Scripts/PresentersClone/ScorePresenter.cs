using UnityEngine;
using Assets.Scripts.ModelsClone;

namespace Assets.Scripts.PresentersClone
{
    public class ScorePresenter : IPresenter
    {
        private readonly Score _score;
        private readonly ScoreView _view;

        public ScorePresenter(Score score, ScoreView view)
        {
            _score = score;
            _view = view;
        }

        public void Enable()
        {
            _score.CountChanged += OnScoreChanged;
            _view.CollisionEntered += OnCollisionEnter;
        }

        public void Disable()
        {
            _score.CountChanged -= OnScoreChanged;
            _view.CollisionEntered += OnCollisionEnter;
        }

        private void OnCollisionEnter(Collider collider)
        {
            if (collider.TryGetComponent(out IDestructible destructible))
            {
                if (destructible is CubeGroupItemView)
                {
                    _score.Add();
                }

                destructible.Destruct();
            }
        }

        private void OnScoreChanged(int count)
        {
            _view.SetScoreText(count);
            _view.SetProgressBar((float)count / _score.MaxCount);
        }
    }
}