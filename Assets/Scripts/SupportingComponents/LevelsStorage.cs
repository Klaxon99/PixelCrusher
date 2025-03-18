using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsStorage", menuName = "UIContent/LevelsStorage")]
public class LevelsStorage : ScriptableObject
{
    [SerializeField] private List<Level> _items;

    private Dictionary<int, Level> _levels;

    public IEnumerable<Level> Items => GetItems();

    public void Init()
    {
        _levels = _items.ToDictionary(item => item.SceneId, item => item);
    }

    private IEnumerable<Level> GetItems()
    {
        int firstLevel = 1;
        Level currentLevel = _levels[firstLevel];

        if (currentLevel == null)
        {
            throw new InvalidOperationException();
        }

        while (currentLevel != null)
        {
            yield return currentLevel;

            currentLevel = currentLevel.NextLevel;
        }
    }

    public Level GetLevelById(int levelId) => _levels[levelId];
}