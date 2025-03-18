using Assets.Scripts.Factories;
using Assets.Scripts.Models;
using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.Presenters
{
    public class ProjectilePresenter : IPresenter
    {
        private readonly Projectile _model;
        private readonly ProjectileView _view;
        private readonly ProjectileFactory _projectileFactory;

        public ProjectilePresenter(Projectile model, ProjectileView view, ProjectileFactory projectileFactory)
        {
            _model = model;
            _view = view;
            _projectileFactory = projectileFactory;
        }

        public void Enable()
        {
            _model.VelocityChanged += OnVelocityChanged;
            _view.CollisionEntered += OnCollisionEnter;
            _view.Destructed += OnDestructible;
        }

        public void Disable()
        {
            _model.VelocityChanged -= OnVelocityChanged;
            _view.CollisionEntered -= OnCollisionEnter;
            _view.Destructed -= OnDestructible;
        }

        private void OnVelocityChanged()
        {
            _view.SetVelocity(_model.Velocity);
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
                Collider[] colliders = Physics.OverlapSphere(contactPoint.point, _model.InteractionRadius);

                foreach (Collider collider in colliders)
                {
                    if (collider.TryGetComponent(out IInteractable interactable))
                    {
                        interactable.Touch(-Vector3.forward * _model.InteractionForce);
                    }
                }
            }

            _model.Reflect(contactPoint.normal);
        }
    }
}