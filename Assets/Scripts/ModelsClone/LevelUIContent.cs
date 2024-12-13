using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.ModelsClone
{
    public class LevelUIContent
    {
        private readonly PlayerData _playerData;
        private readonly LevelsStorage _levelsStorage;

        public LevelUIContent(LevelsStorage levelsStorage, PlayerData playerData)
        {
            _playerData = playerData;
            _levelsStorage = levelsStorage;
        }

        public IEnumerable<LevelUIItem> AvailableLevels => _levelsStorage.Items.Where(item => (int)item.Level <= _playerData.LastPassedLevel);

        public IEnumerable<LevelUIItem> PrivateLevels => _levelsStorage.Items.Where(item => (int)item.Level > _playerData.LastPassedLevel);
    }
}