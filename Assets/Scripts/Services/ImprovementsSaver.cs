using Assets.Scripts.Models;
using UnityEngine.SceneManagement;
using YG;

namespace Assets.Scripts.Services
{
    public class ImprovementsSaver : IProgressSaver
    {
        private readonly Wallet _wallet;
        private readonly GunLevelImprover _gunImprover;

        public ImprovementsSaver(Wallet wallet, GunLevelImprover gunImprover)
        {
            _wallet = wallet;
            _gunImprover = gunImprover;
        }

        public void Save()
        {
            YandexGame.savesData.GunLevel = _gunImprover.CurrentLevel.Number;
            YandexGame.savesData.Wallet = _wallet;

            if (YandexGame.savesData.LastPassedLevelId < SceneManager.GetActiveScene().buildIndex)
            {
                YandexGame.savesData.LastPassedLevelId = SceneManager.GetActiveScene().buildIndex;
            }

            YandexGame.SaveProgress();
        }
    }
}