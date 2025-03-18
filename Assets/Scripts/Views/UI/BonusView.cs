using Assets.Scripts.Presenters;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views
{
    public class BonusView : PopUpView
    {
        [SerializeField] private Button _bonusButton;
        [SerializeField] private Button _closeButton;

        public event Action BonusButtonClick;

        public event Action CloseButtonClick;

        public override void Init(IPresenter presenter)
        {
            base.Init(presenter);

            _bonusButton.onClick.AddListener(OnBonusButtonClicked);
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnCloseButtonClick() => CloseButtonClick?.Invoke();

        private void OnBonusButtonClicked() => BonusButtonClick?.Invoke();
    }
}