using Assets.Scripts.Views;
using System;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class CubeGroupItem : MonoBehaviour, ICubeGroupItem, IDestructible, IInteractable
{
    private Transform _transform;
    private ICubeGroup _cubeGroup;
    private Rigidbody _rigidbody;

    public Vector2 GroupPosition {get; private set;}

    public void Init()
    {
        _transform = transform;
        GroupPosition = _transform.localPosition;
    }

    public void SetParentGroup(ICubeGroup cubeGroup, Transform transform)
    {
        _cubeGroup = cubeGroup ?? throw new ArgumentNullException();
        _transform.SetParent(transform);
    }

    public void Free()
    {
        _transform.SetParent(null);
        _cubeGroup = null;
        _rigidbody = gameObject.AddComponent<Rigidbody>();
    }
    
    public void Touch(Vector3 force)
    {
        _cubeGroup?.Detach(this);
        _rigidbody?.AddForce(force, ForceMode.Impulse);
    }

    public void Destruct()
    {
        _cubeGroup?.Detach(this);
        gameObject.SetActive(false);
    }
}