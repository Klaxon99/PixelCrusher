using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Models
{
    public class LevelUIContent : PopUpModel
    {
        private readonly PlayerData _playerData;
        private readonly LevelsStorage _levelsStorage;

        public LevelUIContent(LevelsStorage levelsStorage, PlayerData playerData)
        {
            _playerData = playerData;
            _levelsStorage = levelsStorage;
        }

        public IEnumerable<Level> GetAvailableLevels => _levelsStorage.Items.Where(item => item.SceneId <= _playerData.LastPassedLevelId + 1);

        public IEnumerable<Level> GetPrivateLevels => _levelsStorage.Items.Where(item => item.SceneId > _playerData.LastPassedLevelId + 1);
    }
}