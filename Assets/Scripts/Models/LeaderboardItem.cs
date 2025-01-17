using UnityEngine;

namespace Assets.Scripts.Models
{
    public class LeaderboardItem
    {
        public LeaderboardItem(Sprite image, string nickName, int score, int position)
        {
            Image = image;
            Nickname = nickName;
            Score = score;
            Position = position;
        }

        public Sprite Image { get; private set; }

        public string Nickname { get; private set; }

        public int Score { get; private set; }

        public int Position { get; private set; }
    }
}