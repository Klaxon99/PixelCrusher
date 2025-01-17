using UnityEngine;

[CreateAssetMenu(fileName = "LevelUIContentFactory", menuName = "UIContent/LevelUIContentFactory")]
public class LevelUIContentFactory : ScriptableObject
{
    [SerializeField] private LevelUIItemView _prefab;

    public LevelUIItemView Create(Level level, RectTransform parent, bool isActive)
    {
        LevelUIItemView contentView = Instantiate(_prefab, parent);

        contentView.Init(level, isActive);

        return contentView;
    }
}