using Assets.Scripts.ModelsClone;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.PresentersClone
{
    public class PauseMenuPresenter : IPresenter
    {
        private const int MainMenuSceneIndex = 0;

        private readonly PauseMenuView _view;
        private readonly Game _model;
        private readonly SoundSwitcher _soundSwitcher;

        public PauseMenuPresenter(Game model, PauseMenuView view)
        {
            _model = model;
            _view = view;
        }

        public void Enable()
        {
            _view.OpenButtonClicked += OnOpenButtonClicked;
            _view.CloseButtonClicked += OnCloseButtonClicked;
            _view.MainMenuButtonClicked += OnMainMenuButtonClicked;
            _model.Paused += OnPaused;
            _model.Unpaused += OnUnpaused;
        }
        
        public void Disable()
        {

        }

        private void OnCloseButtonClicked()
        {
            _view.gameObject.SetActive(false);
        }

        private void OnMainMenuButtonClicked()
        {
            SceneManager.LoadScene(MainMenuSceneIndex);
        }

        private void OnOpenButtonClicked()
        {
            _view.gameObject.SetActive(true);
        }

        private void OnUnpaused()
        {
            Time.timeScale = 1;
        }

        private void OnPaused()
        {
            Time.timeScale = 0;
        }
    }
}