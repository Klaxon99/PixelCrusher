using Assets.Scripts.Models;
using Assets.Scripts.Services;

namespace Assets.Scripts.Presenters
{
    public class EndGamePresenter : IPresenter
    {
        private readonly EndGameScreenView _view;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameMission _gameMission;
        private readonly IProgressSaver _progressSaver;

        public EndGamePresenter(IGameMission gameMission, IProgressSaver progressSaver, EndGameScreenView view, SceneLoader sceneLoader)
        {
            _gameMission = gameMission;
            _view = view;
            _sceneLoader = sceneLoader;
            _progressSaver = progressSaver;
        }

        public void Enable()
        {
            _gameMission.Succeeded += OnGameOver;
            _view.NextLevelButtonClicked += OnNextLevelButtonClicked;
            _view.ReloadLevelButtonClicked += OnReloadLevelButtonClicked;
            _view.MainMenuButtonClicked += OnMainMenuButtonClicked;
        }

        public void Disable()
        {
            _gameMission.Succeeded -= OnGameOver;
            _view.NextLevelButtonClicked -= OnNextLevelButtonClicked;
            _view.ReloadLevelButtonClicked -= OnReloadLevelButtonClicked;
            _view.MainMenuButtonClicked -= OnMainMenuButtonClicked;
        }

        private void OnGameOver()
        {
            _progressSaver.Save();
            _view.Show();
        }

        private void OnMainMenuButtonClicked()
        {
            _sceneLoader.LoadMainMenu();
        }

        private void OnReloadLevelButtonClicked()
        {
            _sceneLoader.ReloadCurrentLevel();
        }

        private void OnNextLevelButtonClicked()
        {
            _sceneLoader.LoadNextLevel();
        }
    }
}