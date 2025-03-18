using Assets.Scripts.Presenters;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views
{
    public class EndGameScreenView : PopUpView
    {
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Button _reloadLevelButton;
        [SerializeField] private Button _mainMenuButton;

        private IPresenter _presenter;

        public event Action NextLevelButtonClicked;

        public event Action ReloadLevelButtonClicked;

        public event Action MainMenuButtonClicked;

        public override void Init(IPresenter presenter)
        {
            _presenter = presenter;

            _nextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);
            _reloadLevelButton.onClick.AddListener(OnReloadLevelButtonClicked);
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);

            _presenter.Enable();
        }

        protected override void OnDisable()
        {
            _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClicked);
            _reloadLevelButton.onClick.RemoveListener(OnReloadLevelButtonClicked);
            _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);

            _presenter.Disable();
        }

        private void OnNextLevelButtonClicked()
        {
            NextLevelButtonClicked?.Invoke();
        }

        private void OnReloadLevelButtonClicked()
        {
            ReloadLevelButtonClicked?.Invoke();
        }

        private void OnMainMenuButtonClicked()
        {
            MainMenuButtonClicked?.Invoke();
        }
    }
}