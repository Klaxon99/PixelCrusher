using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelUIContent", menuName = "UIContent/LevelsStorage")]
public class LevelsStorage : ScriptableObject
{
    [SerializeField] private List<Level> _items;

    private Dictionary<int, Level> _levels;

    public IEnumerable<Level> Items => _items;

    public void Init()
    {
        _levels = _items.ToDictionary(item => item.SceneId, item => item);
    }

    public Level GetLevelById(int levelId) => _levels[levelId];
}