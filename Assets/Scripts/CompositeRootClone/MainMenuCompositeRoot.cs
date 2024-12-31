using Assets.Scripts.ModelsClone;
using Assets.Scripts.PresentersClone;
using System.Collections.Generic;
using System.Linq;
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
        LevelUIContent levelUIContent = new LevelUIContent(_levelsStorage, new PlayerData(2));
        IEnumerable<LevelUIItemView> availableLevels = levelUIContent.AvailableLevels.Select(item => _levelUIContentFactory.Create(item, _levelUIContentView.RectTransform, true));
        IEnumerable<LevelUIItemView> privateLevels = levelUIContent.PrivateLevels.Select(item => _levelUIContentFactory.Create(item, _levelUIContentView.RectTransform, false));
        LevelUIContentPresenter levelUIContentPresenter = new LevelUIContentPresenter(levelUIContent, _levelUIContentView);

        _levelUIContentView.SetContent(availableLevels.Union(privateLevels));
        _levelUIContentView.Init(levelUIContentPresenter);

        SoundSwitcher soundSwitcher = new SoundSwitcher(_soundSettings);
        SoundPresenter soundPresenter = new SoundPresenter(soundSwitcher, _soundView);

        if (_soundSettings.IsMute)
        {
            _soundView.Mute();
        }
        else
        {
            _soundView.Unmute();
        }

        _soundView.Init(soundPresenter);
    }
}