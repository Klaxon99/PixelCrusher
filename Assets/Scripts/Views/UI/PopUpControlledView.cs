using Assets.Scripts.Presenters;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views
{
    public abstract class PopUpControlledView : PopUpView
    {
        [SerializeField] private Button _openButton;
        [SerializeField] private Button _closeButton;

        public event Action OpenButtonClicked;

        public event Action CloseButtonClicked;

        public override void Init(IPresenter presenter)
        {
            base.Init(presenter);

            _openButton.onClick.AddListener(OnOpenButtonClicked);
            _closeButton.onClick.AddListener(OnCloseButtonClicked);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _openButton.onClick.RemoveListener(OnOpenButtonClicked);
            _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
        }

        private void OnCloseButtonClicked()
        {
            CloseButtonClicked?.Invoke();
        }

        private void OnOpenButtonClicked()
        {
            OpenButtonClicked?.Invoke();
        }
    }
}