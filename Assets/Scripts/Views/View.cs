using Assets.Scripts.Presenters;
using UnityEngine;

namespace Assets.Scripts.Views
{
    public abstract class View : MonoBehaviour
    {
        private IPresenter _presenter;

        public virtual void Init(IPresenter presenter)
        {
            _presenter= presenter;

            _presenter.Enable();
        }

        protected virtual void OnDisable()
        {
            _presenter.Disable();
        }
    }
}