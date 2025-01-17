using Assets.Scripts.Models;
using Assets.Scripts.Views;
using System;

namespace Assets.Scripts.Presenters
{
    public class LeaderboardPresenter : IPresenter
    {
        private readonly Leaderboard _model;
        private readonly LeaderboardView _view;

        public LeaderboardPresenter(Leaderboard model, LeaderboardView view)
        {
            _model = model;
            _view = view;
        }

        public void Disable()
        {
            _view.OpenButtonClicked -= OnOpenButtonClicked;
            _view.CloseButtonClicked -= OnCloseButtonClicked;
        }

        public void Enable()
        {
            _view.OpenButtonClicked += OnOpenButtonClicked;
            _view.CloseButtonClicked += OnCloseButtonClicked;
        }

        private void OnCloseButtonClicked()
        {
            _view.Hide();
        }

        private void OnOpenButtonClicked()
        {
            _view.Show();
        }
    }
}