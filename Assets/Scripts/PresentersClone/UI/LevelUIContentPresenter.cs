using Assets.Scripts.ModelsClone;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.PresentersClone
{
    public class LevelUIContentPresenter
    {
        private readonly LevelUIContent _model;
        private readonly LevelUIContentView _view;
        private readonly LevelUIContentFactory _levelUIContentFactory;

        public LevelUIContentPresenter(LevelUIContent model, LevelUIContentView view, LevelUIContentFactory levelUIContentFactory)
        {
            _model = model;
            _view = view;
            _levelUIContentFactory = levelUIContentFactory;

            InitView();
            Enable();
        }

        public void Enable()
        {
            _view.LevelSelected += OnLevelSelected;
            _view.OpenButtonClicked += OnOpenButtonClicked;
            _view.CloseButtonClicked += OnCloseButtonClicked;
        }

        private void InitView()
        {
            IEnumerable<LevelUIItemView> availableLevels = _model.AvailableLevels.Select(item => _levelUIContentFactory.Create(item, _view.RectTransform, true));
            IEnumerable<LevelUIItemView> privateLevels = _model.PrivateLevels.Select(item => _levelUIContentFactory.Create(item, _view.RectTransform, false));

            _view.Init(availableLevels.Union(privateLevels));
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