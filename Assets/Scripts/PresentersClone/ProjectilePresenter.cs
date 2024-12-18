using Assets.Scripts.FactoriesClone;
using Assets.Scripts.ModelsClone;
using UnityEngine;

namespace Assets.Scripts.PresentersClone
{
    public class ProjectilePresenter : IPresenter
    {
        private readonly Projectile _model;
        private readonly ProjectileView _view;
        private readonly ProjectileFactory _factory;
        private readonly ProjectileSettings _projectileSettings;

        public ProjectilePresenter(Projectile model, ProjectileView view, ProjectileFactory projectileFactory, ProjectileSettings projectileSettings)
        {
            _model = model;
            _view = view;
            _factory = projectileFactory;
            _projectileSettings = projectileSettings;

            _view.Init(this, _model.Velocity);
        }

        public void Enable()
        {
            _model.VelocityChanged += OnVelocityChange;
            _view.CollisionEntered += OnCollisionEnter;
            _view.Destructible += OnDestructible;
        }

        public void Disable()
        {
            _model.VelocityChanged -= OnVelocityChange;
            _view.CollisionEntered -= OnCollisionEnter;
            _view.Destructible -= OnDestructible;
        }

        private void OnDestructible()
        {
            _factory.Destroy(_view);
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

            Vector3 normal = contactPoint.normal;
            Vector3 projectNormal = Vector3.ProjectOnPlane(normal, _view.transform.up).normalized;

            _model.Reflect(projectNormal);
        }

        private void OnVelocityChange()
        {
            _view.SetVelocity(_model.Velocity);
        }
    }
}