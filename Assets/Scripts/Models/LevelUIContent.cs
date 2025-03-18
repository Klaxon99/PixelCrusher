using System.Collections.Generic;

namespace Assets.Scripts.Models
{
    public class LevelUIContent
    {
        private int _lastPassedLevel;
        private Dictionary<int, Level> _availableLevels;
        private List<Level> _privateLevels;

        public LevelUIContent(IEnumerable<Level> levels, int lastPassedLevel)
        {
            _lastPassedLevel = lastPassedLevel;
            _availableLevels = new Dictionary<int, Level>();
            _privateLevels = new List<Level>();

            foreach (Level level in levels)
            {
                int nextLevelId = _lastPassedLevel + 1;

                if (level.SceneId <= nextLevelId)
                {
                    _availableLevels[level.SceneId] = level;
                }
                else
                {
                    _privateLevels.Add(level);
                }
            }
        }

        public IReadOnlyDictionary<int, Level> AvailableLevels => _availableLevels;

        public IEnumerable<Level> PrivateLevels => _privateLevels; 
    }
}