using System;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Services
{
    public class SceneLoader
    {
        private const string MainMenuSceneName = "MainMenu";

        private readonly LevelsStorage _levelsStorage;

        public SceneLoader(LevelsStorage levelsStorage)
        {
            _levelsStorage = levelsStorage;
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(MainMenuSceneName);
        }

        public void LoadNextLevel()
        {
            int currentLevelId = SceneManager.GetActiveScene().buildIndex;

            LoadLevel(_levelsStorage.GetLevelById(currentLevelId).NextLevel);
        }

        public void LoadLevel(Level level)
        {
            if (level == null)
            {
                throw new ArgumentNullException();
            }

            SceneManager.LoadScene(level.SceneName);
        }

        public void ReloadCurrentLevel()
        {
            LoadLevel(_levelsStorage.GetLevelById(SceneManager.GetActiveScene().buildIndex));
        }
    }
}