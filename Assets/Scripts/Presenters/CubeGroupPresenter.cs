using System;
using System.Collections.Generic;
using Assets.Scripts.Factories;
using Assets.Scripts.Models;
using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.Presenters
{
    public class CubeGroupPresenter : IPresenter
    {
        private readonly CubeGroup _model;
        private readonly CubeGroupView _view;
        private readonly ICubeGroupFactory _factory;

        public CubeGroupPresenter(CubeGroup model, CubeGroupView view, ICubeGroupFactory factory)
        {
            _view = view ?? throw new ArgumentNullException();
            _factory = factory ?? throw new ArgumentNullException();
            _model = model ?? throw new ArgumentNullException();
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

        private void OnGroupSplited(IEnumerable<Vector2> positions)
        {
            _factory.Create(positions);
        }

        private void OnItemDetached(CubeGroupItem cubeView)
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