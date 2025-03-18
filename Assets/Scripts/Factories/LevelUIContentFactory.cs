using UnityEngine;

namespace Assets.Scripts.Factories
{
    [CreateAssetMenu(fileName = "LevelUIContentFactory", menuName = "UIContent/LevelUIContentFactory")]
    public class LevelUIContentFactory : ScriptableObject
    {
        [SerializeField] private LevelUIItem _prefab;

        public LevelUIItem Create(Level level, RectTransform parent, bool isActive)
        {
            LevelUIItem contentView = Instantiate(_prefab, parent);

            contentView.Init(level.SceneId, level.Image, isActive);

            return contentView;
        }
    }
}