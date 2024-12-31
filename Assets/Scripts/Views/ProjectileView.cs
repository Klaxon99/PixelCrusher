using Assets.Scripts.ModelsClone;
using Assets.Scripts.PresentersClone;
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

    public event Action Destructible;

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

    public void SetVelocity(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }    

    public void Destruct()
    {
        Destructible?.Invoke();
    }
}