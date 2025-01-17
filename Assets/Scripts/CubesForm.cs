using Assets.Scripts.Factories;
using System.Collections.Generic;
using UnityEngine;

public class CubesForm : MonoBehaviour, ICubeStorage
{
    private Dictionary<Vector2, CubeGroupItemView> _cubes;

    public int ItemsCount => _cubes.Count;

    public IEnumerable<Vector2> ItemsPositions => _cubes.Keys;

    public void Init()
    {
        _cubes = new Dictionary<Vector2, CubeGroupItemView>();
        CubeGroupItemView[] childs = transform.GetComponentsInChildren<CubeGroupItemView>();

        foreach (CubeGroupItemView child in childs)
        {
            child.Init();
            _cubes[child.GroupPosition] = child;
        }
    }

    public CubeGroupItemView GetItem(Vector2 position)
    {
        return _cubes[position];
    }
}