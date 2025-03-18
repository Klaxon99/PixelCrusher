using UnityEngine;
using UnityEngine.UI;
using System;
using Assets.Scripts.Presenters;

namespace Assets.Scripts.Views
{
    public class PauseMenuView : PopUpControlledView
    {
        [SerializeField] private Button _mainMenuButton;

        public event Action MainMenuButtonClicked;

        public override void Init(IPresenter presenter)
        {
            base.Init(presenter);

            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
        }

        private void OnMainMenuButtonClicked()
        {
            MainMenuButtonClicked?.Invoke();
        }
    }
}