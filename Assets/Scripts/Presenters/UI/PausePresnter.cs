using Assets.Scripts.Models;
using Assets.Scripts.Services;
using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.Presenters
{
    public class PausePresnter : PopupPresenter<PauseMenuView>
    {
        private readonly PauseSwitcher _model;
        private readonly SceneLoader _sceneLoader;

        public PausePresnter(PauseSwitcher model, PauseMenuView view, SceneLoader sceneLoader) : base(view)
        {
            _model = model;
            _sceneLoader = sceneLoader;
        }

        public override void Enable()
        {
            base.Enable();

            _model.Paused += OnPaused;
            _model.Unpaused += OnUnpaused;
            View.MainMenuButtonClicked += OnMainMenuButtonClicked;
            Application.focusChanged += OnGameFocusChanged;

            OnUnpaused();
        }

        public override void Disable()
        {
            base.Disable();

            _model.Paused -= OnPaused;
            _model.Unpaused -= OnUnpaused;
            View.MainMenuButtonClicked -= OnMainMenuButtonClicked;
            Application.focusChanged -= OnGameFocusChanged;
        }

        protected override void OnOpenButtonClicked() => _model.Pause();

        protected override void OnCloseButtonClicked() => _model.Unpause();

        private void OnGameFocusChanged(bool isActive)
        {
            if (isActive == false)
            {
                _model.Pause();
            }
        }

        private void OnMainMenuButtonClicked()
        {
            _sceneLoader.LoadMainMenu();
        }

        private void OnUnpaused()
        {
            Time.timeScale = 1;
            View.Hide();
        }

        private void OnPaused()
        {
            Time.timeScale = 0;
            View.Show();
        }
    }
}
