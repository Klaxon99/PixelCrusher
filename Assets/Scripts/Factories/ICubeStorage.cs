using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public interface ICubeStorage : IReadOnlyCubeStorage
    {
        IEnumerable<Vector2> ItemsPositions { get; }

        CubeGroupItemView GetItem(Vector2 position);
    }
}