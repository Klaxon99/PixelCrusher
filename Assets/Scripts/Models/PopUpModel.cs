using System;

namespace Assets.Scripts.Models
{
    public abstract class PopUpModel
    {
        public event Action Opened;

        public event Action Closed;

        public virtual void Show()
        {
            Opened?.Invoke();
        }

        public virtual void Hide()
        {
            Closed?.Invoke();
        }
    }
}