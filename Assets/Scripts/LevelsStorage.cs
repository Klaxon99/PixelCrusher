using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelUIContent", menuName = "UIContent/LevelsStorage")]
public class LevelsStorage : ScriptableObject
{
    [SerializeField] private List<LevelUIItem> _items;

    public IEnumerable<LevelUIItem> Items => _items;
}