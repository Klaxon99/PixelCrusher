public interface IGunLevelInfo
{
    public int Number { get; }

    public int Price { get; }

    public IGunLevelInfo NextLevel { get; }

    public string LevelDescription { get; }
}