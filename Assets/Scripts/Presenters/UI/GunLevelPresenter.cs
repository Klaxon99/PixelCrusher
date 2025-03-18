using Assets.Scripts.Models;
using Assets.Scripts.Services;
using Assets.Scripts.Views;

namespace Assets.Scripts.Presenters
{
    public class GunLevelPresenter : PopupPresenter<GunImprovementsView>
    {
        private readonly GunLevelImprover _gunImprover;
        private readonly Wallet _wallet;
        private readonly IProgressSaver _progressSaver;

        public GunLevelPresenter(GunLevelImprover gunImprover, Wallet wallet, GunImprovementsView view, IProgressSaver progressSaver) : base(view)
        {
            _gunImprover = gunImprover;
            _progressSaver = progressSaver;
            _wallet = wallet;
        }

        public override void Enable()
        {
            base.Enable();

            View.Hide();
            View.ImproveButtonClicked += ImproveButtonClicked;
            _gunImprover.Improved += OnGunImproved;

            TryUpdateView();
        }

        public override void Disable()
        {
            View.ImproveButtonClicked -= ImproveButtonClicked;
            _gunImprover.Improved -= OnGunImproved;
        }

        protected override void OnOpenButtonClicked()
        {
            if (_gunImprover.NextLevel != null)
            {
                View.Show();
            }
        }

        private bool TryUpdateView()
        {
            bool canUpdate = _gunImprover.NextLevel != null;

            if (canUpdate)
            {
                View.SetPrice(_gunImprover.NextLevel.Price);
                View.SetDescription(_gunImprover.NextLevel.LevelDescription);
            }

            return canUpdate;
        }

        private void OnGunImproved()
        {
            _wallet.Reduce(_gunImprover.CurrentLevel.Price);
            _progressSaver.Save();

            if (TryUpdateView() == false)
            {
                View.Hide();
            }
        }

        private void ImproveButtonClicked()
        {
            if (_gunImprover.CanImprove(_wallet))
            {
                _gunImprover.Improve(_wallet);
            }
        }
    }
}