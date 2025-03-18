using Assets.Scripts.Models;
using Assets.Scripts.Services;
using Assets.Scripts.Views;

namespace Assets.Scripts.Presenters
{
    public class BonusPresenter : IPresenter
    {
        private readonly BonusView _view;
        private readonly RewardBonusService _rewardBonusService;
        private readonly Wallet _wallet;
        private readonly IReadOnlyScore _score;
        private readonly IGameMission _gameMission;

        public BonusPresenter(Wallet wallet, IReadOnlyScore score, BonusView view, RewardBonusService rewardBonusService, IGameMission gameMission)
        {
            _view = view;
            _rewardBonusService = rewardBonusService;
            _wallet = wallet;
            _score = score;
            _gameMission = gameMission;
        }

        public void Enable()
        {
            _view.Hide();

            _gameMission.Succeeded += OnGameOver;
            _view.BonusButtonClick += OnBonusButtonClick;
            _view.CloseButtonClick += OnCloseButtonClick;
        }

        public void Disable()
        {
            _gameMission.Succeeded -= OnGameOver;
            _view.BonusButtonClick -= OnBonusButtonClick;
            _view.CloseButtonClick -= OnCloseButtonClick;
        }

        private void OnCloseButtonClick() => _view.Hide();

        private void OnGameOver() => _view.Show();

        private void OnBonusButtonClick()
        {
            _rewardBonusService.ShowVideo(() => _wallet.Add(_score.Count));
            _view.Hide();
        }
    }
}