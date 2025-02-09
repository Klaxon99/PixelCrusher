using Assets.Scripts.Models;
using UnityEngine.SceneManagement;
using YG;

namespace Assets.Scripts.Services
{
    public class DataSaver : IProgressSaver
    {
        private readonly Score _score;

        public DataSaver(Score score)
        {
            _score = score;
        }

        public void Save()
        {
            YandexGame.savesData.Wallet.Add(_score.Count);

            if (YandexGame.savesData.PlayerData.LastPassedLevelId < SceneManager.GetActiveScene().buildIndex)
            {
                YandexGame.savesData.PlayerData.IterateLastPassedLevel();
            }

            YandexGame.SaveProgress();
        }
    }
}