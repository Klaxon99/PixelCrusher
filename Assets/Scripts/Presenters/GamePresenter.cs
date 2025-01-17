using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Presenters
{
    public class GamePresenter : IPresenter
    {
        private readonly Game _model;
        private readonly GameView _view;
        private readonly IGameMission _gameMission;
        private readonly IPauseSwitcher _pauseSwitcher;

        public GamePresenter(Game model, GameView view, IPauseSwitcher pauseSwitcher, IGameMission gameMission)
        {
            _model = model;
            _view = view;
            _pauseSwitcher = pauseSwitcher;
            _gameMission = gameMission;
        }

        public void Enable()
        {
            _model.Over += OnGameOver;
            _gameMission.Succeeded += _model.Stop;
            _view.PauseButtonPressed += OnPauseButtonClicked;
            Application.focusChanged += OnGameFocusChanged;
        }

        private void OnGameFocusChanged(bool state)
        {
            if (state == false)
            {
                _pauseSwitcher.Pause();
            }
        }

        public void Disable()
        {
            _model.Over -= OnGameOver;
            _gameMission.Succeeded -= _model.Stop;
            _view.PauseButtonPressed -= OnPauseButtonClicked;
            Application.focusChanged -= OnGameFocusChanged;
        }

        private void OnGameOver()
        {
            Debug.Log("SaveProgress");
        }

        private void OnPauseButtonClicked()
        {
            _pauseSwitcher.Pause();
        }
    }
}