using Assets.Scripts.Presenters;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views
{
    [RequireComponent(typeof(RectTransform))]
    public class LeaderboardView : PopUpView, IView
    {
        [SerializeField] private Button _openButton;
        [SerializeField] private Button _closeButton;

        private IPresenter _presenter;

        public event Action OpenButtonClicked;

        public event Action CloseButtonClicked;

        public RectTransform RectTransform { get; private set; }

        public void Init(IPresenter presenter)
        {
            RectTransform = GetComponent<RectTransform>();
            _presenter = presenter;

            _openButton.onClick.AddListener(OnOpenButtonClicked);
            _closeButton.onClick.AddListener(OnCloseButtonClicked);

            _presenter.Enable();
        }

        private void OnDisable()
        {
            _openButton.onClick.RemoveListener(OnOpenButtonClicked);
            _closeButton.onClick.RemoveListener(OnCloseButtonClicked);

            _presenter.Disable();
        }

        private void OnOpenButtonClicked()
        {
            OpenButtonClicked?.Invoke();
        }

        private void OnCloseButtonClicked()
        {
            CloseButtonClicked?.Invoke();
        }   
    }
}