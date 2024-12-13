using System;
using Assets.Scripts.FactoriesClone;

namespace Assets.Scripts.ModelsClone
{
    public class CubeGroupPresenter
    {
        private readonly CubeGroup _model;
        private readonly CubeGroupView _view;
        private readonly ICubeGroupFactory _factory;

        public CubeGroupPresenter(CubeGroup model, CubeGroupView view, ICubeGroupFactory factory)
        {
            _view = view ?? throw new ArgumentNullException();
            _factory = factory ?? throw new ArgumentNullException();
            _model = model ?? throw new ArgumentNullException();

            Enable();
        }

        public void Enable()
        {
            _model.Emptied += OnEmptied;
            _model.Splited += OnSplited;
            _view.ItemDetached += OnDetached;
            _view.ItemDestructed += OnItemDestructed;
        }

        public void Disable()
        {
            _model.Emptied -= OnEmptied;
            _model.Splited -= OnSplited;
            _view.ItemDetached -= OnDetached;

            _factory.Destruct(_view);
        }

        private void OnItemDestructed(CubeGroupItem item)
        {
            item.gameObject.SetActive(false);
            item.gameObject.GetComponent<CubeFreed>().enabled = true;


        }

        private void OnSplited(CubeGroup group)
        {
            _factory.Create(group);
        }

        private void OnDetached(CubeGroupItem cubeView)
        {
            cubeView.Free();
            _model.Remove(cubeView.GroupPosition);
        }

        private void OnEmptied()
        {
            Disable();
        }
    }
}