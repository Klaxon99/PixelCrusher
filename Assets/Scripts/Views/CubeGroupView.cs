using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
public class CubeGroupView : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody _rigidbody;
    private RigidbodyConstraints _constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    private List<CubeGroupItem> _items;

    public event Action<CubeGroupItem> ItemDetached;

    public event Action<CubeGroupItem> ItemDestructed;

    public void Init(IEnumerable<CubeGroupItem> items)
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = _constraints;
        _items = new List<CubeGroupItem>();

        foreach (CubeGroupItem item in items)
        {
            _rigidbody.mass++;

            item.SetParent(_transform);
            item.Detached += OnItemDetached;
            item.Destructed += OnItemDestructed;

            _items.Add(item);
        }
    }

    private void OnItemDestructed(CubeGroupItem item)
    {
        item.Destructed -= OnItemDestructed;
        OnItemDetached(item);

        ItemDestructed?.Invoke(item);
    }

    private void OnDestroy()
    {
        foreach (CubeGroupItem item in _items)
        {
            item.Detached -= OnItemDetached;
        }
    }

    public void OnItemDetached(CubeGroupItem item)
    {
        _rigidbody.mass--;
        item.Detached -= OnItemDetached;
        _items.Remove(item);
        ItemDetached?.Invoke(item);
    }
}