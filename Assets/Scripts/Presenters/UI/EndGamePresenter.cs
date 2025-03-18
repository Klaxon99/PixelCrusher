using Assets.Scripts.Models;
using Assets.Scripts.Services;
using Assets.Scripts.Views;

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

            _view.Hide();
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
            _view.Show();
        }

        private void OnMainMenuButtonClicked()
        {
            _progressSaver.Save();
            _sceneLoader.LoadMainMenu();
        }

        private void OnReloadLevelButtonClicked()
        {
            _progressSaver.Save();
            _sceneLoader.ReloadCurrentLevel();
        }

        private void OnNextLevelButtonClicked()
        {
            _progressSaver.Save();
            _sceneLoader.LoadNextLevel();
        }
    }
}