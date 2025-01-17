using Assets.Scripts.Models;
using Assets.Scripts.Presenters;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(AudioSource))]
public class ProjectileView : MonoBehaviour, IView, IDestructible
{
    private Rigidbody _rigidbody;
    private Transform _transform;
    private IPresenter _presenter;

    public AudioSource AudioSource { get; private set; }

    public event Action<Collision> CollisionEntered;

    public event Action Destructed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = _rigidbody.transform;
        AudioSource = GetComponent<AudioSource>();
    }

    public void Init(IPresenter presenter)
    {
        _presenter = presenter;

        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionEntered?.Invoke(collision);
    }

    public void SetOrientation(SpaceOrientation spaceOrientation)
    {
        _transform.SetPositionAndRotation(spaceOrientation.Position, spaceOrientation.Rotation);
    }

    public void SetVelocityDirection(Vector3 value)
    {
        _rigidbody.velocity = value;
    }

    public void SetSpeed(float value)
    {
        _rigidbody.velocity = _rigidbody.velocity.normalized * value;
    }

    public void Destruct()
    {
        Destructed?.Invoke();
    }
}