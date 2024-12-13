using System;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(CubeFreed))]
public class CubeGroupItem : MonoBehaviour, ICubeGroupItem, IDestructible, IInteractable
{
    private Transform _transform;

    public event Action<CubeGroupItem> Detached;

    public event Action<CubeGroupItem> Destructed;

    public Vector2 GroupPosition {get; private set;}

    public void Init()
    {
        _transform = transform;
        GroupPosition = _transform.localPosition;
    }

    public void SetParent(Transform transform)
    {
        _transform.SetParent(_transform);
    }

    public void Free()
    {
        _transform.SetParent(null);
    }
    
    public void Touch(Vector3 force)
    {
        Detached?.Invoke(this);
    }

    public void Destruct()
    {
        Destructed?.Invoke(this);
    }
}