using Assets.Scripts.Models;
using Assets.Scripts.Presenters;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class GunBuilder : MonoBehaviour, IGunFactory
    {
        [SerializeField] private ServiceUpdater _updateService;
        [SerializeField] private GunBaseSettings _baseGunSettings;
        [SerializeField] private ProjectileSettings _projectileSettings;
        [SerializeField] private UIInput _input;

        private Timers _timers;
        private ProjectileFactory _projectileFactory;
        private IGunMovement _gunMovement;
        private IShootControlSystem _shootControlSystem;
        private Dictionary<GunImprovement, IGunMovement> _improvements;

        public void Init()
        {
            _timers = new Timers(_updateService);
            _projectileFactory = new ProjectileFactory(_projectileSettings);
            _shootControlSystem = new SingleShotSystem(_timers, _baseGunSettings.ReloadTime);
            _improvements = new Dictionary<GunImprovement, IGunMovement>();
        }

        public GunView Create(SpaceOrientation spaceOrientation)
        {
            Gun gun = new Gun(spaceOrientation, new GunBaseMovement(), new BurstShootingSystem(_timers, _baseGunSettings.ReloadTime));
            GunView view = Instantiate(_baseGunSettings.GunPrefab);
            GunPresenter gunPresenter = new GunPresenter(gun, view, _input, _updateService, _projectileFactory);
            view.SetOrientation(spaceOrientation);
            view.Init(gunPresenter);

            return view;
        }

        public void AddDynamicMovement()
        {
            _gunMovement = new GunDynamicMovement(_baseGunSettings.ReloadTime, 5f);
        }

        public void AddBurstShootingSystem()
        {

        }
    }
}