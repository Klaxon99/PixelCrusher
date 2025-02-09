using Assets.Scripts.Models;
using Assets.Scripts.Services;
using UnityEngine;

namespace Assets.Scripts.Presenters
{
    public class PausePresnter : IPresenter
    {
        private readonly PauseSwitcher _model;
        private readonly PauseMenuView _view;
        private readonly SceneLoader _sceneLoader;

        public PausePresnter(PauseSwitcher model, PauseMenuView view, SceneLoader sceneLoader)
        {
            _model = model;
            _view = view;
            _sceneLoader = sceneLoader;
        }

        public void Enable()
        {
            _model.Paused += OnPaused;
            _model.Unpaused += OnUnpaused;
            _view.CloseButtonClicked += OnCloseButtonClicked;
            _view.MainMenuButtonClicked += OnMainMenuButtonClicked;
            _view.OpenButtonClicked += OnOpenButtonClicked;
            Application.focusChanged += OnGameFocusChanged;

            OnUnpaused();
        }

        public void Disable()
        {
            _model.Paused -= OnPaused;
            _model.Unpaused -= OnUnpaused;
            _view.CloseButtonClicked -= OnCloseButtonClicked;
            _view.MainMenuButtonClicked -= OnMainMenuButtonClicked;
            _view.OpenButtonClicked -= OnOpenButtonClicked;
            Application.focusChanged -= OnGameFocusChanged;
        }

        private void OnGameFocusChanged(bool isActive)
        {
            if (isActive)
            {
                _model.Pause();
            }
            else
            {
                _model.Unpause();
            }
        }

        private void OnOpenButtonClicked()
        {
            _model.Pause();
        }

        private void OnMainMenuButtonClicked()
        {
            _sceneLoader.LoadMainMenu();
        }

        private void OnCloseButtonClicked()
        {
            _model.Unpause();
        }

        private void OnUnpaused()
        {
            Time.timeScale = 1;
            _view.Hide();
        }

        private void OnPaused()
        {
            Time.timeScale = 0;
            _view.Show();
        }
    }
}
