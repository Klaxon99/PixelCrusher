using System;
using System.Linq;
using UnityEngine;
using Assets.Scripts.ModelsClone;

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
            view.Init(model.Items.Select(item => _cubeStorage.GetItem(item)));
            new CubeGroupPresenter(model, view, this);

            return view;
        }

        public void Destruct(CubeGroupView cubeGroupView)
        {
            GameObject.Destroy(cubeGroupView);
        }
    }
}