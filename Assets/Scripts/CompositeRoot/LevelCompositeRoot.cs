using Assets.Scripts.Factories;
using Assets.Scripts.Models;
using Assets.Scripts.Presenters;
using Assets.Scripts.Services;
using UnityEngine;

namespace Assets.Scripts.CompositeRoot
{
    public class LevelCompositeRoot : MonoBehaviour
    {
        [Header("Input")]
        [SerializeField] private UIInput _input;

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

        private Score _score;
        private PauseSwitcher _pauseSwitcher;

        private void Awake()
        {
            ComposeCubeGroup();
            ComposeScore();
            ComposeSound();

            _levelBounds.Init();
            ComposeGun();
            ComposeGame();
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
            factory.Create(new CubeGroup(_cubesForm.ItemsPositions));
        }

        private void ComposeGun()
        {
            _input.Init();
            _gunFactory.Init();
            _gunFactory.Create(new SpaceOrientation(_gunSpawnPoint.position, _gunSpawnPoint.rotation));
        }

        private void ComposeSound()
        {
            SoundPresenter soundPresenter = new SoundPresenter(_soundSettings, _soundView);

            _soundView.Init(soundPresenter);
        }

        private void ComposeGame()
        {
            _levelsStorage.Init();
            _pauseSwitcher = new PauseSwitcher();
            GameMission gameMission = new GameMission(_score);
            SceneLoader sceneLoader = new SceneLoader(_levelsStorage);
            DataSaver dataSaver = new DataSaver(_score);

            PausePresnter pausePresnter = new PausePresnter(_pauseSwitcher, _pauseMenuView, sceneLoader);
            _pauseMenuView.Hide();
            _pauseMenuView.Init(pausePresnter);

            EndGamePresenter endGameScreenPresenter = new EndGamePresenter(gameMission, dataSaver, _endGameScreenView, sceneLoader);
            _pauseMenuView.Hide();
            _endGameScreenView.Init(endGameScreenPresenter);
        }
    }
}