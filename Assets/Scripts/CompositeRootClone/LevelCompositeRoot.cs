using Assets.Scripts.FactoriesClone;
using Assets.Scripts.ModelsClone;
using Assets.Scripts.PresentersClone;
using UnityEngine;

namespace Assets.Scripts.CompositeRootClone
{
    public class LevelCompositeRoot : MonoBehaviour
    {
        [Header("Gun")]
        [SerializeField] private PlayerDesktopInput _playerDesktopInput;
        [SerializeField] private ServiceUpdater _serviceUpdater;
        [SerializeField] private GunSettings _gunSettings;
        [SerializeField] private ProjectileSettings _projectileSettings;
        [SerializeField] private Transform _gunSpawnPoint;

        [Header("CubeForm")]
        [SerializeField] private CubesForm _cubesForm;

        [Header("Score")]
        [SerializeField] private ScoreView _scoreView;

        [Header("LevelBounds")]
        [SerializeField] private Bounds _levelBounds;

        private Score _score;

        private void Awake()
        {
            _levelBounds.Init();
            ComposeGun();
            ComposeCubeGroup();
            ComposeScore();
        }

        private void ComposeScore()
        {
            _score = new Score(_cubesForm.ItemsCount);
            _scoreView.Init(new ScorePresenter(_score, _scoreView));
        }

        private void ComposeCubeGroup()
        {
            _cubesForm.Init();
            CubeGroupFactory factory = new CubeGroupFactory(_cubesForm);
            factory.Create(new CubeGroup(_cubesForm.ItemsPositions));
            Score score = new Score(_cubesForm.ItemsCount);
            _scoreView.Init(new ScorePresenter(score, _scoreView));
        }

        private void ComposeGun()
        {
            GunDynamicMovement gunMovement = new GunDynamicMovement(new GunStaticMovement(), _gunSettings.Speed, 7f);
            BurstShootingSystem burst = new BurstShootingSystem(new Timers(_serviceUpdater), _gunSettings.ReloadTime);
            Gun gun = new Gun(new SpaceOrientation(_gunSpawnPoint.position, _gunSpawnPoint.rotation), gunMovement, burst);
            ProjectileFactory factory = new ProjectileFactory(_projectileSettings);
            GunView view = Instantiate(_gunSettings.GunPrefab);
            view.SetOrientation(gun.SpaceOrientation);
            GunPresenter gunPresenter = new GunPresenter(gun, view, _playerDesktopInput, _serviceUpdater, factory);

            view.Init(gunPresenter);
        }
    }
}