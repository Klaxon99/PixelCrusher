using UnityEngine;

[CreateAssetMenu(fileName = "LevelUIContentFactory", menuName = "UIContent/LevelUIContentFactory")]
public class LevelUIContentFactory : ScriptableObject
{
    [SerializeField] private LevelUIItemView _prefab;

    public LevelUIItemView Create(LevelUIItem uiContentItem, RectTransform parent, bool isActive)
    {
        LevelUIItemView contentView = Instantiate(_prefab, parent);

        contentView.Init(uiContentItem.Image, uiContentItem.Text, uiContentItem.Level, isActive);

        return contentView;
    }
}