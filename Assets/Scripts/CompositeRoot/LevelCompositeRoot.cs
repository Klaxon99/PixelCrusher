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
        [SerializeField] private GunFactory _gunFactory;

        [Header("CubesForm")]
        [SerializeField] private CubesForm _cubesForm;

        [Header("Score")]
        [SerializeField] private ScoreView _scoreView;

        [Header("LevelBounds")]
        [SerializeField] private Bounds _levelBounds;

        [Header("Sound")]
        [SerializeField] private SoundSettings _soundSettings;
        [SerializeField] private SoundView _soundView;

        [Header("Game")]
        [SerializeField] private GameView _gameView;
        [SerializeField] private PauseMenuView _pauseMenuView;
        [SerializeField] private EndGameScreenView _endGameScreenView;
        [SerializeField] private LevelsStorage _levelsStorage;

        private Score _score;
        private Game _game;
        private PauseSwitcher _pauseSwitcher;

        private void Awake()
        {
            ComposeCubeGroup();
            ComposeSound();

            _levelBounds.Init();
            ComposeGun();
            ComposeScore();
            ComposeGame();
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
        }

        private void ComposeGun()
        {
            _input.Init();
            _gunFactory.Init();

            _gunFactory.AddDynamicMovement().AddSingleShootSystem().Create(new SpaceOrientation(_gunSpawnPoint.position, _gunSpawnPoint.rotation));
        }

        private void ComposeSound()
        {
            SoundPresenter soundPresenter = new SoundPresenter(_soundSettings, _soundView);

            _soundView.Init(soundPresenter);
        }

        private void ComposeGame()
        {
            _levelsStorage.Init();
            _game = new Game();
            _pauseSwitcher = new PauseSwitcher();
            GameMission gameMission = new GameMission(_score);
            SceneLoader sceneLoader = new SceneLoader(_levelsStorage);

            GamePresenter gamePresenter = new GamePresenter(_game, _gameView, _pauseSwitcher, gameMission);
            _gameView.Init(gamePresenter);

            PausePresnter pausePresnter = new PausePresnter(_pauseSwitcher, _pauseMenuView, sceneLoader);
            _pauseMenuView.Hide();
            _pauseMenuView.Init(pausePresnter);

            EndGameScreenPresenter endGameScreenPresenter = new EndGameScreenPresenter(_game, _endGameScreenView, sceneLoader);
            _pauseMenuView.Hide();
            _endGameScreenView.Init(endGameScreenPresenter);
        }
    }
}