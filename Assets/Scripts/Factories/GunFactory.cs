using Assets.Scripts.Models;
using Assets.Scripts.Presenters;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class GunFactory : MonoBehaviour
    {
        [SerializeField] private ServiceUpdater _updateService;
        [SerializeField] private GunSettings _gunSettings;
        [SerializeField] private ProjectileSettings _projectileSettings;
        [SerializeField] private UIInput _input;

        private Timers _timers;
        private ProjectileFactory _projectileFactory;
        private IShootControlSystem _shootControlSystem;
        private IGunMovement _movement;

        public void Init()
        {
            _timers = new Timers(_updateService);
            _projectileFactory = new ProjectileFactory(_projectileSettings);
        }

        public GunFactory AddDynamicMovement()
        {
            _movement = new GunDynamicMovement(_gunSettings.Speed, 5f);

            return this;
        }

        public GunFactory AddStaticMovement()
        {
            _movement = new GunBaseMovement();

            return this;
        }

        public GunFactory AddSingleShootSystem()
        {
            _shootControlSystem = new SingleShotSystem(_timers, _gunSettings.ReloadTime);

            return this;
        }

        public GunFactory AddBurstShootSystem()
        {
            _shootControlSystem = new BurstShootingSystem(_timers, _gunSettings.ReloadTime);

            return this;
        }

        public GunView Create(SpaceOrientation spaceOrientation)
        {
            Gun gun = new Gun(spaceOrientation, _movement, _shootControlSystem);
            GunView view = GameObject.Instantiate(_gunSettings.GunPrefab);
            GunPresenter gunPresenter = new GunPresenter(gun, view, _input, _updateService, _projectileFactory);
            view.SetOrientation(spaceOrientation);
            view.Init(gunPresenter);

            return view;
        }
    }
}