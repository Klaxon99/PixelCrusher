using System;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class PlayerData
    {
        public PlayerData(string nickname, int lastPassedLevelId)
        {
            Nickname = nickname;
            LastPassedLevelId = lastPassedLevelId;
        }

        public string Nickname { get; private set; }

        public int LastPassedLevelId { get; private set; }

        public void IterateLastPassedLevel()
        {
            LastPassedLevelId++;
        }
    }
}