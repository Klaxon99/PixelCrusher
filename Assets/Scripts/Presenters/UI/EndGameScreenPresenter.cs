using Assets.Scripts.Models;
using Assets.Scripts.Services;

namespace Assets.Scripts.Presenters
{
    public class EndGameScreenPresenter : IPresenter
    {
        private readonly EndGameScreenView _view;
        private readonly IGame _model;
        private readonly SceneLoader _sceneLoader;

        public EndGameScreenPresenter(IGame model, EndGameScreenView view, SceneLoader sceneLoader)
        {
            _view = view;
            _model = model;
            _sceneLoader = sceneLoader;
        }

        public void Enable()
        {
            _model.Over += OnGameOver;
            _view.NextLevelButtonClicked += OnNextLevelButtonClicked;
            _view.ReloadLevelButtonClicked += OnReloadLevelButtonClicked;
            _view.MainMenuButtonClicked += OnMainMenuButtonClicked;
        }

        public void Disable()
        {
            _model.Over -= OnGameOver;
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