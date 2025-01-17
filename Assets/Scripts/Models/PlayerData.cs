namespace Assets.Scripts.Models
{
    public class PlayerData
    {
        public PlayerData(int lastPassedLevelId)
        {
            LastPassedLevelId = lastPassedLevelId;
        }

        public int LastPassedLevelId { get; }
    }
}