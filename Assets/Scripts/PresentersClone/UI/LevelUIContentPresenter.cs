using Assets.Scripts.ModelsClone;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.PresentersClone
{
    public class LevelUIContentPresenter : IPresenter
    {
        private readonly LevelUIContent _model;
        private readonly LevelUIContentView _view;

        public LevelUIContentPresenter(LevelUIContent model, LevelUIContentView view)
        {
            _model = model;
            _view = view;
        }

        public void Enable()
        {
            _view.LevelSelected += OnLevelSelected;
            _view.OpenButtonClicked += OnOpenButtonClicked;
            _view.CloseButtonClicked += OnCloseButtonClicked;
        }

        public void Disable()
        {
            _view.LevelSelected -= OnLevelSelected;
            _view.OpenButtonClicked -= OnOpenButtonClicked;
            _view.CloseButtonClicked -= OnCloseButtonClicked;
        }

        private void OnCloseButtonClicked()
        {
            _view.gameObject.SetActive(false);
        }

        private void OnOpenButtonClicked()
        {
            _view.gameObject.SetActive(true);
        }

        private void OnLevelSelected(Levels level)
        {
            SceneManager.LoadScene((int)level);
        }
    }
}