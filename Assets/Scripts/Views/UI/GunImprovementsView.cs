using Assets.Scripts.Presenters;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views
{
    public class GunImprovementsView : PopUpControlledView
    {
        [SerializeField] private Button _improveButton;
        [SerializeField] private TMP_Text _description;
        [SerializeField] public TMP_Text _price;

        public event Action ImproveButtonClicked;

        public override void Init(IPresenter presenter)
        {
            base.Init(presenter);

            _improveButton.onClick.AddListener(OnImproveButtonClicked);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _improveButton.onClick.RemoveListener(OnImproveButtonClicked);
        }

        public void SetPrice(float value) => _price.text = value.ToString();

        public void SetDescription(string text) => _description.text = text;

        private void OnImproveButtonClicked() => ImproveButtonClicked?.Invoke();
    }
}