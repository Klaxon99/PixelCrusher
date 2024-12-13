using System;
using UnityEngine;

namespace Assets.Scripts.PresentersClone
{
    public class SoundSwitchPresenter
    {
        private readonly ISoundSwitcher _model;
        private readonly SoundView _view;

        public SoundSwitchPresenter(ISoundSwitcher model, SoundView view)
        {
            _model = model;
            _view = view;

            Enable();
        }

        public void Enable()
        {
            _view.Clicked += OnClicked;
            _model.Muted += OnMuted;
            _model.Unmuted += OnUnmuted;
        }

        public void Disable()
        {
            _view.Clicked -= OnClicked;
            _model.Muted -= OnMuted;
            _model.Unmuted -= OnUnmuted;
        }

        private void OnUnmuted()
        {
            throw new NotImplementedException();
        }

        private void OnMuted()
        {
            throw new NotImplementedException();
        }

        private void OnClicked()
        {
        }
    }
}