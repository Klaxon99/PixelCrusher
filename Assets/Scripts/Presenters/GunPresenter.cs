using Assets.Scripts.Factories;
using Assets.Scripts.Models;
using Assets.Scripts.Views;

namespace Assets.Scripts.Presenters
{
    public class GunPresenter : IPresenter
    {
        private readonly Gun _gunModel;
        private readonly GunView _gunView;
        private readonly IInput _input;
        private readonly IUpdateService _updateService;
        private readonly IProjectileFactory _projectileFactory;

        private Timers _timers;

        public GunPresenter(Gun model, GunView view, IInput input, IUpdateService updateService, IProjectileFactory projectileFactory)
        {
            _gunModel = model;
            _gunView = view;
            _input = input;
            _updateService = updateService;
            _projectileFactory = projectileFactory;
            _timers = new Timers(_updateService);
        }

        public void Enable()
        {
            _gunModel.Shot += OnShot;
            _gunModel.SpaceOrientationChanged += OnSpaceOrientationChanged;
            _input.ShootKeyPressed += OnShootKeyPressed;
            _updateService.Updated += OnUpdated;
            _timers.Start();
        }

        public void Disable()
        {
            _gunModel.Shot -= OnShot;
            _gunModel.SpaceOrientationChanged -= OnSpaceOrientationChanged;
            _input.ShootKeyPressed -= OnShootKeyPressed;
            _updateService.Updated -= OnUpdated;
            _timers.Stop();
        }

        private void OnSpaceOrientationChanged(SpaceOrientation orientation)
        {
            _gunView.SetOrientation(orientation);
        }

        private void OnShot()
        {
            _projectileFactory.Create(new SpaceOrientation(_gunView.ShootPoint.position, _gunModel.SpaceOrientation.Rotation));
            _gunView.ShootSound.Play();
        }

        private void OnUpdated(float deltaTime) => _gunModel.Transform(_input, deltaTime);

        private void OnShootKeyPressed() => _gunModel.Shoot(_timers);
    }
}