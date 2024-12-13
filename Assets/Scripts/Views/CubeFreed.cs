using System;
using UnityEngine;

public class CubeFreed : MonoBehaviour, IDestructible
{
    private Rigidbody _rigidbody;
    private MovementTrack _movementTrack;

    public event Action Distructed;

    private void OnEnable()
    {
        _movementTrack = GetComponent<MovementTrack>();
        _rigidbody = gameObject.AddComponent<Rigidbody>();

        _movementTrack.enabled = true;
    }

    public void Destruct()
    {
        Distructed?.Invoke();
    }
}