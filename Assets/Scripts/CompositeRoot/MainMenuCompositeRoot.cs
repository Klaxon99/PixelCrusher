using Assets.Scripts.Models;
using Assets.Scripts.Presenters;
using Assets.Scripts.Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.CompositeRoot
{
    public class MainMenuCompositeRoot : MonoBehaviour
    {
        [Header("Levels")]
        [SerializeField] private LevelsStorage _levelsStorage;
        [SerializeField] private LevelUIContentView _levelUIContentView;
        [SerializeField] private LevelUIContentFactory _levelUIContentFactory;

        [Header("Sound")]
        [SerializeField] private SoundSettings _soundSettings;
        [SerializeField] private SoundView _soundView;

        private PlayerData _playerData;

        private void Start()
        {
            ComposePlayerData();
            ComposeLevels();
            ComposeSound();
        }

        private void ComposeSound()
        {
            SoundPresenter soundPresenter = new SoundPresenter(_soundSettings, _soundView);

            _soundView.Init(soundPresenter);
        }

        private void ComposePlayerData()
        {
            _playerData = new PlayerData(1);
        }

        private void ComposeLevels()
        {
            _levelsStorage.Init();
            LevelUIContent levelUIContent = new LevelUIContent(_levelsStorage, _playerData);
            IEnumerable<LevelUIItemView> availableLevels = levelUIContent.GetAvailableLevels.Select(item => _levelUIContentFactory.Create(item, _levelUIContentView.RectTransform, true));
            IEnumerable<LevelUIItemView> privateLevels = levelUIContent.GetPrivateLevels.Select(item => _levelUIContentFactory.Create(item, _levelUIContentView.RectTransform, false));
            SceneLoader sceneLoader = new SceneLoader(_levelsStorage);
            LevelUIContentPresenter levelUIContentPresenter = new LevelUIContentPresenter(levelUIContent, _levelUIContentView, sceneLoader);

            _levelUIContentView.SetContent(availableLevels.Union(privateLevels));
            _levelUIContentView.Init(levelUIContentPresenter);
        }
    }
}