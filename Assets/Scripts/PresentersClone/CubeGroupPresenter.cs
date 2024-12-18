using System;
using System.Linq;
using Assets.Scripts.FactoriesClone;
using Assets.Scripts.PresentersClone;

namespace Assets.Scripts.ModelsClone
{
    public class CubeGroupPresenter : IPresenter
    {
        private readonly CubeGroup _model;
        private readonly CubeGroupView _view;
        private readonly ICubeGroupFactory _factory;

        public CubeGroupPresenter(CubeGroup model, CubeGroupView view, ICubeGroupFactory factory, ICubeStorage cubeStorage)
        {
            _view = view ?? throw new ArgumentNullException();
            _factory = factory ?? throw new ArgumentNullException();
            _model = model ?? throw new ArgumentNullException();

            view.Init(this, model.Items.Select(item => cubeStorage.GetItem(item)));
        }

        public void Enable()
        {
            _model.Emptied += OnGroupEmptied;
            _model.Splited += OnGroupSplited;
            _view.ItemDetached += OnItemDetached;
        }

        public void Disable()
        {
            _model.Emptied -= OnGroupEmptied;
            _model.Splited -= OnGroupSplited;
            _view.ItemDetached -= OnItemDetached;
        }

        private void OnGroupSplited(CubeGroup model)
        {
            _factory.Create(model);
        }

        private void OnItemDetached(CubeGroupItemView cubeView)
        {
            _model.Remove(cubeView.GroupPosition);
            cubeView.Free();
        }

        private void OnGroupEmptied()
        {
            _factory.Destruct(_view);
        }
    }
}