using System.Collections.Generic;

namespace Assets.Scripts.Models
{
    public class Leaderboard
    {
        private readonly List<LeaderboardItem> _items;

        public Leaderboard(List<LeaderboardItem> items)
        {
            _items = items;
        }
    }
}