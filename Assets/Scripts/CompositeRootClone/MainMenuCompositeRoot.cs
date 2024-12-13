using Assets.Scripts.ModelsClone;
using Assets.Scripts.PresentersClone;
using UnityEngine;

public class MainMenuCompositeRoot : MonoBehaviour
{
    [SerializeField] private LevelsStorage _levelsStorage;
    [SerializeField] private LevelUIContentView _levelUIContentView;
    [SerializeField] private LevelUIContentFactory _levelUIContentFactory;
    [SerializeField] private SoundSettings _soundSettings;
    [SerializeField] private SoundView _soundView;

    private void Awake()
    {
        LevelUIContent levelUIContent = new LevelUIContent(_levelsStorage, new PlayerData(1));
        LevelUIContentPresenter levelUIContentPresenter = new LevelUIContentPresenter(levelUIContent, _levelUIContentView, _levelUIContentFactory);
    }
}