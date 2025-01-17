﻿namespace Assets.Scripts.Presenters
{
    public class SoundPresenter : IPresenter
    {
        private readonly SoundSettings _model;
        private readonly SoundView _view;

        public SoundPresenter(SoundSettings model, SoundView view)
        {
            _model = model;
            _view = view;
        }

        public void Enable()
        {
            if (_model.IsMute)
            {
                _view.Mute();
            }
            else
            {
                _view.Unmute();
            }

            _model.Muted += OnMuted;
            _model.Unmuted += OnUnmuted;
            _view.Clicked += OnClicked;
        }

        public void Disable()
        {
            _model.Muted -= OnMuted;
            _model.Unmuted -= OnUnmuted;
            _view.Clicked -= OnClicked;
        }

        private void OnUnmuted()
        {
            _view.Unmute();
        }

        private void OnMuted()
        {
            _view.Mute();
        }

        private void OnClicked()
        {
            _model.SwitchState();
        }
    }
}