using System;
using YG;

namespace Assets.Scripts.Services
{
    public class RewardBonusService : IEventService
    {
        private Action _action;

        public void Stop()
        {
            YandexGame.RewardVideoEvent -= OnRewardVideoEvent;
        }

        public void Start()
        {
            YandexGame.RewardVideoEvent += OnRewardVideoEvent;
        }

        public void ShowVideo(Action onSuccessAction)
        {
            int rewardId = 0;
            _action = onSuccessAction;
            YandexGame.RewVideoShow(rewardId);
        }

        private void OnRewardVideoEvent(int obj)
        {
            _action?.Invoke();
            _action = null;
        }
    }
}