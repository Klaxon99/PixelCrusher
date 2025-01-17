using Assets.Scripts.Factories;
using UnityEngine;

namespace Assets.Scripts.Presenters
{
    public class ProjectilePresenter : IPresenter
    {
        private readonly ProjectileView _view;
        private readonly ProjectileFactory _projectileFactory;
        private readonly ProjectileSettings _projectileSettings;

        public ProjectilePresenter(ProjectileView view, ProjectileFactory projectileFactory, ProjectileSettings projectileSettings)
        {
            _view = view;
            _projectileFactory = projectileFactory;
            _projectileSettings = projectileSettings;
        }

        public void Enable()
        {
            _view.CollisionEntered += OnCollisionEnter;
            _view.Destructed += OnDestructible;
        }

        public void Disable()
        {
            _view.CollisionEntered -= OnCollisionEnter;
            _view.Destructed -= OnDestructible;
        }

        private void OnDestructible()
        {
            _projectileFactory.Destroy(_view);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_view.AudioSource.isPlaying == false)
            {
                _view.AudioSource.Play();
            }

            ContactPoint contactPoint = collision.contacts[0];

            if (collision.collider.TryGetComponent(out IInteractable cube))
            {
                Collider[] colliders = Physics.OverlapSphere(contactPoint.point, _projectileSettings.InteractionRadius);

                foreach (Collider collider in colliders)
                {
                    if (collider.TryGetComponent(out IInteractable interactable))
                    {
                        interactable.Touch(-Vector3.forward * _projectileSettings.InteractionForce);
                    }
                }
            }

            _view.SetSpeed(_projectileSettings.Speed);
        }
    }
}