using Assets.Scripts.Models;
using Assets.Scripts.Presenters;
using Assets.Scripts.Views;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class GunBuilder : MonoBehaviour, IGunFactory, IGunInitializer
    {
        [SerializeField] private ServiceFixedUpdater _updateService;
        [SerializeField] private ProjectileSettings _projectileSettings;
        [SerializeField] private GunInput _input;
        [SerializeField] private GunView _view;
        [SerializeField] private List<GunLevel> _levels;

        private ProjectileFactory _projectileFactory;
        private IGunMovement _gunMovement;
        private IShootControlSystem _shootControlSystem;

        public void Init()
        {
            _projectileFactory = new ProjectileFactory(_projectileSettings);
            _gunMovement = new GunBaseMovement();
            _shootControlSystem = new GunBaseShootSystem(3f);
        }

        public GunView Create(SpaceOrientation spaceOrientation, int gunLevel)
        {
            ApplyImprovements(gunLevel);
            GunView view = Instantiate(_view);
            Gun model = new Gun(spaceOrientation, _gunMovement, _shootControlSystem);
            GunPresenter gunPresenter = new GunPresenter(model, view, _input, _updateService, _projectileFactory);
            view.Init(gunPresenter);
            view.SetOrientation(spaceOrientation);

            return view;
        }

        public void SetShootControlSystem(IShootControlSystem shootControlSystem)
        {
            _shootControlSystem = shootControlSystem;
        }

        public void SetMovement(IGunMovement gunMovement)
        {
            _gunMovement = gunMovement;
        }

        private void ApplyImprovements(int currentGunLevel)
        {
            foreach (IGunImprover gunLevel in _levels.Where(item => item.Number <= currentGunLevel))
            {
                gunLevel.Improve(this);
            }
        }
    }
}