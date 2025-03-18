using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "UIContent/Level")]
public class Level : ScriptableObject
{
    [field: SerializeField] public Sprite Image { get; private set; }

    [field: SerializeField] public string SceneName { get; private set; }

    [field: SerializeField] public int SceneId { get; private set; }

    [field: SerializeField] public Level NextLevel { get; private set; }
}