using Assets.Scripts.Models;
using Assets.Scripts.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace Assets.Scripts.Presenters
{
    public class GamePresenter : IPresenter
    {
        private readonly GameView _view;
        private readonly IGameMission _gameMission;
        private readonly IProgressSaver _progressSaver;

        public GamePresenter(GameView view, IGameMission gameMission, IProgressSaver progressSaver)
        {
            _view = view;
            _gameMission = gameMission;
            _progressSaver = progressSaver;
        }

        public void Enable()
        {
            _gameMission.Succeeded += OnGameOver;
        }

        public void Disable()
        {
            _gameMission.Succeeded -= OnGameOver;
        }

        private void OnGameOver()
        {
            _progressSaver.Save();
        }
    }
}