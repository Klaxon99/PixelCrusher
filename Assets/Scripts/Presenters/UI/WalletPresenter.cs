using Assets.Scripts.Models;

namespace Assets.Scripts.Presenters
{
    public class WalletPresenter : IPresenter
    {
        private readonly IResourceCounter _counter;
        private readonly ValueView _view;

        public WalletPresenter(IResourceCounter counter, ValueView view)
        {
            _counter = counter;
            _view = view;
        }

        public void Enable()
        {
            _counter.CountChanged += OnCountChanged;
        }

        public void Disable()
        {
            _counter.CountChanged -= OnCountChanged;
        }

        private void OnCountChanged(int value)
        {
            _view.SetTextValue(value.ToString());
        }
    }
}