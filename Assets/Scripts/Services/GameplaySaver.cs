using Assets.Scripts.Models;
using UnityEngine.SceneManagement;
using YG;

namespace Assets.Scripts.Services
{
    public class GameplaySaver : IProgressSaver
    {
        private readonly Score _score;
        private readonly LeaderBoardService _leaderBoardService;

        public GameplaySaver(Score score, LeaderBoardService leaderBoardService)
        {
            _score = score;
            _leaderBoardService = leaderBoardService;
        }

        public void Save()
        {
            YandexGame.savesData.Wallet.Add(_score.Count);

            if (YandexGame.savesData.LastPassedLevelId < SceneManager.GetActiveScene().buildIndex)
            {
                YandexGame.savesData.LastPassedLevelId = SceneManager.GetActiveScene().buildIndex;
            }

            YandexGame.SaveProgress();

            _leaderBoardService.Record(YandexGame.savesData.Wallet);
        }
    }
}