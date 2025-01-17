using Assets.Scripts.Models;
using Assets.Scripts.Services;

namespace Assets.Scripts.Presenters
{
    public class LevelUIContentPresenter : IPresenter
    {
        private readonly PopUpModel _model;
        private readonly LevelUIContentView _view;
        private readonly SceneLoader _sceneLoader;

        public LevelUIContentPresenter(PopUpModel model, LevelUIContentView view, SceneLoader sceneLoader)
        {
            _model = model;
            _view = view;
            _sceneLoader = sceneLoader;
        }

        public void Enable()
        {
            _model.Opened += OnOpened;
            _model.Closed += OnClosed;
            _view.LevelSelected += OnLevelSelected;
            _view.OpenButtonClicked += OnOpenButtonClicked;
            _view.CloseButtonClicked += OnCloseButtonClicked;

            _model.Hide();
        }

        public void Disable()
        {
            _model.Opened -= OnOpened;
            _model.Closed -= OnClosed;
            _view.LevelSelected -= OnLevelSelected;
            _view.OpenButtonClicked -= OnOpenButtonClicked;
            _view.CloseButtonClicked -= OnCloseButtonClicked;
        }

        private void OnClosed()
        {
            _view.Hide();
        }

        private void OnOpened()
        {
            _view.Show();
        }

        private void OnCloseButtonClicked()
        {
            _model.Hide();
        }

        private void OnOpenButtonClicked()
        {
            _model.Show();
        }

        private void OnLevelSelected(Level level)
        {
            _sceneLoader.LoadLevel(level);
        }
    }
}