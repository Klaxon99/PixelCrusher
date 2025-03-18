using Assets.Scripts.Factories;
using Assets.Scripts.Models;
using Assets.Scripts.Presenters;
using Assets.Scripts.Views;
using Assets.Scripts.Services;
using UnityEngine;
using YG;

namespace Assets.Scripts.CompositeRoot
{
    public class LevelCompositeRoot : MonoBehaviour
    {
        [Header("Input")]
        [SerializeField] private GunInput _input;

        [Header("Gun")]
        [SerializeField] private Transform _gunSpawnPoint;
        [SerializeField] private GunBuilder _gunFactory;

        [Header("CubesForm")]
        [SerializeField] private CubesForm _cubesForm;

        [Header("Score")]
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private ScoreZoneView _scoreZoneView;

        [Header("LevelBounds")]
        [SerializeField] private Bounds _levelBounds;

        [Header("Sound")]
        [SerializeField] private SoundSettings _soundSettings;
        [SerializeField] private SoundView _soundView;

        [Header("Game")]
        [SerializeField] private PauseMenuView _pauseMenuView;
        [SerializeField] private EndGameScreenView _endGameScreenView;
        [SerializeField] private LevelsStorage _levelsStorage;
        [SerializeField] private BonusView _bonusView;

        private Score _score;
        private RewardBonusService _rewardBonusService;
        private LeaderBoardService _leaderBoardService;
        private GameMission _gameMission;

        private void Start()
        {
            _input.Init();
            _levelBounds.Init();

            ComposeCubeGroup();
            ComposeScore();
            ComposeServices();
            ComposeSound();
            ComposeGun();
            ComposeGame();
        }

        private void OnDisable()
        {
            _rewardBonusService.Stop();
            _leaderBoardService.Stop();
            _gameMission.Stop();
        }

        private void ComposeServices()
        {
            _rewardBonusService = new RewardBonusService();
            _leaderBoardService = new LeaderBoardService();
            _gameMission = new GameMission(_score);

            _rewardBonusService.Start();
            _leaderBoardService.Start();
            _gameMission.Start();
        }

        private void ComposeScore()
        {
            _score = new Score(_cubesForm.ItemsCount);
            _scoreView.Init(new ScorePresenter(_score, _scoreView));
            _scoreZoneView.Init(new ScoreZonePresenter(_score, _scoreZoneView));
        }

        private void ComposeCubeGroup()
        {
            _cubesForm.Init();
            CubeGroupFactory factory = new CubeGroupFactory(_cubesForm);
            factory.Create(_cubesForm.ItemsPositions);
        }

        private void ComposeGun()
        {
            _gunFactory.Init();
            _gunFactory.Create(new SpaceOrientation(_gunSpawnPoint.position, _gunSpawnPoint.rotation), YandexGame.savesData.GunLevel);
        }

        private void ComposeSound()
        {
            SoundPresenter soundPresenter = new SoundPresenter(_soundSettings, _soundView);

            _soundView.Init(soundPresenter);
        }

        private void ComposeGame()
        {
            _levelsStorage.Init();
            
            SceneLoader sceneLoader = new SceneLoader(_levelsStorage);
            GameplaySaver dataSaver = new GameplaySaver(_score, _leaderBoardService);

            PauseSwitcher pauseSwitcher = new PauseSwitcher();
            PausePresnter pausePresnter = new PausePresnter(pauseSwitcher, _pauseMenuView, sceneLoader);
            _pauseMenuView.Init(pausePresnter);

            EndGamePresenter endGamePresenter = new EndGamePresenter(_gameMission, dataSaver, _endGameScreenView, sceneLoader);
            _endGameScreenView.Init(endGamePresenter);

            _bonusView.Init(new BonusPresenter(YandexGame.savesData.Wallet, _score, _bonusView, _rewardBonusService, _gameMission));
        }
    }
}