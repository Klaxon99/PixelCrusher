using UnityEngine;

namespace Assets.Scripts.Views
{
    public abstract class PopUpView : View
    {
        [SerializeField] private Canvas _canvas;

        public void Show() => _canvas.enabled = true;

        public void Hide() => _canvas.enabled = false;
    }
}