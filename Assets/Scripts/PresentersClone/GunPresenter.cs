using System;
using Assets.Scripts.FactoriesClone;
using Assets.Scripts.ModelsClone;
using UnityEngine;

namespace Assets.Scripts.PresentersClone
{
    public class GunPresenter
    {
        private readonly Gun _model;
        private readonly GunView _view;
        private readonly IInput _input;
        private readonly IUpdateService _updateService;
        private readonly IProjectileFactory _projectileFactory;

        public GunPresenter(Gun model, GunView view, IInput input, IUpdateService updateService, IProjectileFactory projectileFactory)
        {
            _model = model ?? throw new ArgumentNullException();
            _view = view ?? throw new ArgumentNullException();
            _input = input ?? throw new ArgumentNullException();
            _updateService = updateService ?? throw new ArgumentNullException();
            _projectileFactory = projectileFactory ?? throw new ArgumentNullException();

            Enable();
        }

        protected void Enable()
        {
            _model.Shot += OnShot;
            _model.SpaceOrientationChanged += OnSpaceOrientationChanged;
            _input.ShootKeyPressed += OnShootKeyPressed;
            _updateService.Updated += OnUpdated;
        }

        protected void Disable()
        {
            _model.Shot -= OnShot;
            _model.SpaceOrientationChanged -= OnSpaceOrientationChanged;
            _input.ShootKeyPressed -= OnShootKeyPressed;
            _updateService.Updated -= OnUpdated;
        }

        private void OnSpaceOrientationChanged(SpaceOrientation orientation)
        {
            _view.SetOrientation(orientation);
        }

        private void OnShootKeyPressed() => _model.Shoot();

        private void OnShot()
        {
            _projectileFactory.Create(new SpaceOrientation(_view.ShootPoint.position, _model.SpaceOrientation.Rotation));
            _view.ShootSound.Play();
        }

        private void OnUpdated(float deltaTime)
        {
            _model.Transform(_input, deltaTime);
        }
    }
}