using Assets.Scripts.Views;

namespace Assets.Scripts.Presenters
{
    public abstract class PopupPresenter<T> : IPresenter where T : PopUpControlledView
    {
        protected T View;

        protected PopupPresenter(T view)
        {
            View = view;
        }

        public virtual void Enable()
        {
            View.OpenButtonClicked += OnOpenButtonClicked;
            View.CloseButtonClicked += OnCloseButtonClicked;
        }

        public virtual void Disable()
        {
            View.OpenButtonClicked -= OnOpenButtonClicked;
            View.CloseButtonClicked -= OnCloseButtonClicked;
        }

        protected virtual void OnCloseButtonClicked() => View.Hide();

        protected virtual void OnOpenButtonClicked() => View.Show();
    }
}