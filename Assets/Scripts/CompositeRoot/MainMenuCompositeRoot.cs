using Assets.Scripts.Factories;
using Assets.Scripts.Models;
using Assets.Scripts.Presenters;
using Assets.Scripts.Services;
using Assets.Scripts.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YG;

namespace Assets.Scripts.CompositeRoot
{
    public class MainMenuCompositeRoot : MonoBehaviour
    {
        [Header("Levels")]
        [SerializeField] private LevelsStorage _levelsStorage;
        [SerializeField] private LevelUIContentView _levelUIContentView;
        [SerializeField] private LevelUIContentFactory _levelUIContentFactory;

        [Header("Gun")]
        [SerializeField] private List<GunLevel> _gunLevels;
        [SerializeField] private GunImprovementsView _gunImprovementsView;

        [Header("Sound")]
        [SerializeField] private SoundSettings _soundSettings;
        [SerializeField] private SoundView _soundView;

        [Header("Wallet")]
        [SerializeField] private ValueView _valueView;

        private void Start()
        {
            ComposeWallet();
            ComposeGunLevels();
            ComposeLevels();
            ComposeSound();
        }

        private void ComposeSound()
        {
            SoundPresenter soundPresenter = new SoundPresenter(_soundSettings, _soundView);

            _soundView.Init(soundPresenter);
        }

        private void ComposeWallet()
        {
            int startSaveId = 0;

            if (YandexGame.savesData.idSave == startSaveId)
            {
                YandexGame.savesData.Wallet = new Wallet();
            }

            WalletPresenter walletPresenter = new WalletPresenter(YandexGame.savesData.Wallet, _valueView);

            _valueView.Init(walletPresenter);
        }

        private void ComposeGunLevels()
        {
            GunLevel currentLevel = null;

            foreach (GunLevel level in _gunLevels)
            {
                level.SetLang(YandexGame.lang);

                if (level.Number == YandexGame.savesData.GunLevel)
                {
                    currentLevel = level;
                }
            }

            if (currentLevel == null)
            {
                throw new InvalidOperationException();
            }

            GunLevelImprover gunLevelImprover = new GunLevelImprover(currentLevel);
            ImprovementsSaver dataSaver = new ImprovementsSaver(YandexGame.savesData.Wallet, gunLevelImprover);

            _gunImprovementsView.Init(new GunLevelPresenter(gunLevelImprover, YandexGame.savesData.Wallet, _gunImprovementsView, dataSaver));
        }

        private void ComposeLevels()
        {
            _levelsStorage.Init();
            LevelUIContent levelUIContent = new LevelUIContent(_levelsStorage.Items, YandexGame.savesData.LastPassedLevelId);
            SceneLoader sceneLoader = new SceneLoader(_levelsStorage);
            LevelUIContentPresenter levelUIContentPresenter = new LevelUIContentPresenter(levelUIContent, _levelUIContentView, sceneLoader);

            IEnumerable<LevelUIItem> availableLevels = levelUIContent.AvailableLevels.Values
                .Select(level => _levelUIContentFactory.Create(level, _levelUIContentView.RectTransform, true));
            IEnumerable<LevelUIItem> privateLevels = levelUIContent.PrivateLevels
                .Select(level => _levelUIContentFactory.Create(level, _levelUIContentView.RectTransform, false));

            _levelUIContentView.SetContent(availableLevels.Union(privateLevels));
            _levelUIContentView.Init(levelUIContentPresenter);
        }
    }
}