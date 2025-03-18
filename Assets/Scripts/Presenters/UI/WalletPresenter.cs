using Assets.Scripts.Models;
using Assets.Scripts.Views;

namespace Assets.Scripts.Presenters
{
    public class WalletPresenter : IPresenter
    {
        private readonly Wallet _wallet;
        private readonly ValueView _view;

        public WalletPresenter(Wallet wallet, ValueView view)
        {
            _wallet = wallet;
            _view = view;
        }

        public void Enable()
        {
            _wallet.MoneyCountChanged += OnCountChanged;

            OnCountChanged(_wallet.Money);
        }

        public void Disable()
        {
            _wallet.MoneyCountChanged -= OnCountChanged;
        }

        private void OnCountChanged(int value)
        {
            _view.SetTextValue(value.ToString());
        }
    }
}