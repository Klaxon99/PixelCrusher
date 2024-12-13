using Assets.Scripts.ModelsClone;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelUIItem", menuName = "UIContent/LevelUIItem")]
public class LevelUIItem : ScriptableObject
{
    [field: SerializeField] public Sprite Image { get; private set; }

    [field: SerializeField] public string Text { get; private set; }

    [field: SerializeField] public Levels Level { get; private set; }
}