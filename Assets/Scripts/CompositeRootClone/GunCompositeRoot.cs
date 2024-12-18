using Assets.Scripts.FactoriesClone;
using Assets.Scripts.ModelsClone;
using Assets.Scripts.PresentersClone;
using UnityEngine;

namespace Assets.Scripts.CompositeRootClone
{
    public class GunCompositeRoot : CompositeRoot
    {
        [SerializeField] private PlayerDesktopInput _playerDesktopInput;
        [SerializeField] private ServiceUpdater _serviceUpdater;
        [SerializeField] private GunSettings _gunSettings;
        [SerializeField] private ProjectileSettings _projectileSettings;
        [SerializeField] private Transform _gunSpawnPoint;

        public override void Init()
        {
            GunDynamicMovement gunMovement = new GunDynamicMovement(new GunStaticMovement(), _gunSettings.Speed, 7f);
            SingleShotSystem singleShotSystem = new SingleShotSystem(new Timers(_serviceUpdater), _gunSettings.ReloadTime);
            BurstShootingSystem burst = new BurstShootingSystem(new Timers(_serviceUpdater), _gunSettings.ReloadTime);
            Gun gun = new Gun(new SpaceOrientation(_gunSpawnPoint.position, _gunSpawnPoint.rotation), gunMovement, singleShotSystem);
            ProjectileFactory factory = new ProjectileFactory(_projectileSettings);
            GunView view = Instantiate(_gunSettings.GunPrefab);
            GunPresenter gunPresenter = new GunPresenter(gun, view, _playerDesktopInput, _serviceUpdater, factory);
        }
    }
}