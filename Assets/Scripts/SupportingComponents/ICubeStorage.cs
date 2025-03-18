using System.Collections.Generic;
using UnityEngine;

public interface ICubeStorage : IReadOnlyCubeStorage
{
    IEnumerable<Vector2> ItemsPositions { get; }

    CubeGroupItem GetItem(Vector2 position);
}