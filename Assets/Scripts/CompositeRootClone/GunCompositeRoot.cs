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
            ProjectileFactory factory = new ProjectileFactory(_projectileSettings);

            GunView view = Instantiate(_gunSettings.GunPrefab, _gunSpawnPoint.position, _gunSpawnPoint.rotation);
            GunDynamicMovement gunMovement = new GunDynamicMovement(new GunStaticMovement(), _gunSettings.Speed, 7f);
            BurstShootingSystem burstShootingSystem = new BurstShootingSystem(new Timers(_serviceUpdater), _gunSettings.ReloadTime);
            Gun gun = new Gun(new SpaceOrientation(view.transform.position, view.transform.rotation), gunMovement, burstShootingSystem);
            new GunPresenter(gun, view, _playerDesktopInput, _serviceUpdater, factory);
        }
    }
}