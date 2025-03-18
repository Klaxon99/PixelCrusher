using Assets.Scripts.Models;
using Assets.Scripts.Services;
using Assets.Scripts.Views;

namespace Assets.Scripts.Presenters
{
    public class LevelUIContentPresenter : PopupPresenter<LevelUIContentView>
    {
        private readonly LevelUIContent _model;
        private readonly SceneLoader _sceneLoader;

        public LevelUIContentPresenter(LevelUIContent model, LevelUIContentView view, SceneLoader sceneLoader) : base(view)
        {
            _model = model;
            _sceneLoader = sceneLoader;
        }

        public override void Enable()
        {
            base.Enable();

            View.LevelSelected += OnLevelSelected;

            View.Hide();
        }

        public override void Disable()
        {
            base.Disable();

            View.LevelSelected -= OnLevelSelected;
        }

        private void OnLevelSelected(int levelId)
        {
            if (_model.AvailableLevels.ContainsKey(levelId))
            {
                _sceneLoader.LoadLevel(_model.AvailableLevels[levelId]);
            }
        }
    }
}