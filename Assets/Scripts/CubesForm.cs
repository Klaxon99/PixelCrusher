using Assets.Scripts.FactoriesClone;
using System.Collections.Generic;
using UnityEngine;

public class CubesForm : MonoBehaviour, ICubeStorage
{
    private Dictionary<Vector2, CubeGroupItem> _cubes;

    public int ItemsCount => _cubes.Count;

    public IEnumerable<Vector2> ItemsPositions => _cubes.Keys;

    public void Init()
    {
        _cubes = new Dictionary<Vector2, CubeGroupItem>();
        var childs = transform.GetComponentsInChildren<CubeGroupItem>();

        foreach (CubeGroupItem child in childs)
        {
            child.Init();
            _cubes[child.GroupPosition] = child;
        }
    }

    public CubeGroupItem GetItem(Vector2 position)
    {
        return _cubes[position];
    }
}