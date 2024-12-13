using Assets.Scripts.ModelsClone;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(AudioSource))]
public class ProjectileView : MonoBehaviour, IDestructible
{
    private Rigidbody _rigidbody;
    private Transform _transform;

    public AudioSource AudioSource { get; private set; }

    public event Action<Collision> CollisionEntered;
    public event Action Disabled;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
        AudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionEntered?.Invoke(collision);
    }

    public void SetVelocity(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }    

    public void SetOrientation(SpaceOrientation spaceOrientation)
    {
        _transform.position = spaceOrientation.Position;
        _transform.rotation = spaceOrientation.Rotation;
    }

    public void Destruct()
    {
        Disabled?.Invoke();
    }
}