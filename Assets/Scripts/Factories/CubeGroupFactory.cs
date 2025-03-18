using System;
using UnityEngine;
using Assets.Scripts.Models;
using System.Linq;
using Assets.Scripts.Presenters;
using System.Collections.Generic;
using Assets.Scripts.Views;

namespace Assets.Scripts.Factories
{
    public class CubeGroupFactory : ICubeGroupFactory
    {
        private readonly ICubeStorage _cubeStorage;

        public CubeGroupFactory(ICubeStorage cubeStorage)
        {
            _cubeStorage = cubeStorage ?? throw new ArgumentNullException();
        }

        public CubeGroupView Create(IEnumerable<Vector2> cubesPositions)
        {
            CubeGroup cubeGroup = new CubeGroup(cubesPositions);
            CubeGroupView view = new GameObject("CubeGroup").AddComponent<CubeGroupView>();
            CubeGroupPresenter presenter = new CubeGroupPresenter(cubeGroup, view, this);

            view.Init(presenter);
            view.SetChilds(cubeGroup.Items.Select(item => _cubeStorage.GetItem(item)));

            return view;
        }

        public void Destruct(CubeGroupView cubeGroupView)
        {
            GameObject.Destroy(cubeGroupView.gameObject);
        }
    }
}