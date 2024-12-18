using System;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(MovementTrack))]
public class CubeGroupItemView : MonoBehaviour, ICubeGroupItem, IDestructible, IInteractable
{
    private Transform _transform;
    private CubeGroupView _cubeGroup;
    private Rigidbody _rigidbody;
    private MovementTrack _movementTrack;

    public Vector2 GroupPosition {get; private set;}

    public void Init()
    {
        _transform = transform;
        GroupPosition = _transform.localPosition;
        _movementTrack = gameObject.GetComponent<MovementTrack>();
        _movementTrack.enabled = false;
    }

    public void SetGroup(CubeGroupView cubeGroup, Transform transform)
    {
        _cubeGroup = cubeGroup ?? throw new ArgumentNullException();
        _transform.SetParent(transform);
    }

    public void Free()
    {
        _transform.SetParent(null);
        _cubeGroup = null;
        _rigidbody = gameObject.AddComponent<Rigidbody>();
        _movementTrack.enabled = true;
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