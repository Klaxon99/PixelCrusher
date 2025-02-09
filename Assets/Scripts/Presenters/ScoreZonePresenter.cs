using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Presenters
{
    public class ScoreZonePresenter : IPresenter
    {
        private readonly Score _score;
        private readonly ScoreZoneView _view;

        public ScoreZonePresenter(Score score, ScoreZoneView view)
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
                if (destructible is CubeGroupItemView)
                {
                    _score.Add();
                }

                destructible.Destruct();
            }
        }
    }
}