using Assets.Scripts.Models;
using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.Presenters
{
    public class ScoreZonePresenter : IPresenter
    {
        private readonly IScoreIterator _score;
        private readonly ScoreZoneView _view;

        public ScoreZonePresenter(IScoreIterator score, ScoreZoneView view)
        {
            _score = score;
            _view = view;
        }

        public void Enable()
        {
            _view.CollisionEntered += OnCollisionEnter;
        }

        public void Disable()
        {
            _view.CollisionEntered -= OnCollisionEnter;
        }

        private void OnCollisionEnter(Collider collider)
        {
            if (collider.TryGetComponent(out IDestructible destructible))
            {
                if (destructible is CubeGroupItem)
                {
                    _score.Add();

                    if (_view.CoinSound.isPlaying == false)
                    {
                        _view.CoinSound.Play();
                    }
                }

                destructible.Destruct();
            }
        }
    }
}