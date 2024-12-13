namespace Assets.Scripts.ModelsClone
{
    public class PlayerData
    {
        public PlayerData(int lastPassedLevel)
        {
            LastPassedLevel = lastPassedLevel;
        }

        public int LastPassedLevel { get; }
    }
}