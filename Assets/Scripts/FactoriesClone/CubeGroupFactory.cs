using System;
using UnityEngine;
using Assets.Scripts.ModelsClone;
using System.Linq;

namespace Assets.Scripts.FactoriesClone
{
    public class CubeGroupFactory : ICubeGroupFactory
    {
        private readonly ICubeStorage _cubeStorage;

        public CubeGroupFactory(ICubeStorage cubeStorage)
        {
            _cubeStorage = cubeStorage ?? throw new ArgumentNullException();
        }

        public CubeGroupView Create(CubeGroup model)
        {
            CubeGroupView view = new GameObject("CubeGroup").AddComponent<CubeGroupView>();
            CubeGroupPresenter cubeGroupPresenter = new CubeGroupPresenter(model, view, this);

            view.Init(cubeGroupPresenter);
            view.SetChilds(model.Items.Select(item => _cubeStorage.GetItem(item)));

            return view;
        }

        public void Destruct(CubeGroupView cubeGroupView)
        {
            GameObject.Destroy(cubeGroupView.gameObject);
        }
    }
}