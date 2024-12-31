using Assets.Scripts.ModelsClone;
using System;
using UnityEngine;

namespace Assets.Scripts.PresentersClone
{
    public class SoundPresenter : IPresenter
    {
        private readonly GameSound _model;
        private readonly SoundView _view;

        public SoundPresenter(GameSound model, SoundView view)
        {
            _model = model;
            _view = view;
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
            _view.Unmute();
        }

        private void OnMuted()
        {
            _view.Mute();
        }

        private void OnClicked()
        {
            _model.SwitchVolume();
        }
    }
}