using Assets.Scripts.Views;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public interface ICubeGroupFactory
    {
        public CubeGroupView Create(IEnumerable<Vector2> cubesPositions);

        public void Destruct(CubeGroupView cubeGroupView);
    }
}