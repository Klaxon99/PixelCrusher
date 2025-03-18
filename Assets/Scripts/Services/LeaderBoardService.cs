using Assets.Scripts.Models;
using YG;
using YG.Utils.LB;

namespace Assets.Scripts.Services
{
    public class LeaderBoardService : IEventService
    {
        private const string LeaderboardTitle = "MoneyLeaderboard";
        private const int QuantityPlayers = 10;
        private const int QuantityTop = 10;
        private const int QuantityAround = 10;
        private const string PhotoSize = "480";

        private LBThisPlayerData _playerData;

        public void Record(IReadOnlyWallet wallet)
        {
            if (_playerData != null)
            {
                if (wallet.Money > _playerData.score)
                {
                    YandexGame.NewLeaderboardScores(LeaderboardTitle, wallet.Money);
                }
            }
        }

        public void Start()
        {
            YandexGame.onGetLeaderboard += OnGetLeaderboard;
            YandexGame.GetLeaderboard(LeaderboardTitle, QuantityPlayers, QuantityTop, QuantityAround, PhotoSize);
        }

        public void Stop()
        {
            YandexGame.onGetLeaderboard -= OnGetLeaderboard;
        }

        private void OnGetLeaderboard(LBData data) => _playerData = data.thisPlayer;
    }
}