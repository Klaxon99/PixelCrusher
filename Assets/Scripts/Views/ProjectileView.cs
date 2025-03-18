using Assets.Scripts.Models;
using System;
using UnityEngine;

namespace Assets.Scripts.Views
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Transform))]
    [RequireComponent(typeof(AudioSource))]
    public class ProjectileView : View, IDestructible
    {
        private Rigidbody _rigidbody;
        private Transform _transform;

        public event Action<Collision> CollisionEntered;

        public event Action Destructed;

        public AudioSource AudioSource { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transform = _rigidbody.transform;
            AudioSource = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            CollisionEntered?.Invoke(collision);
        }

        public void SetVelocity(Vector3 value)
        {
            _rigidbody.velocity = value;
        }

        public void SetOrientation(SpaceOrientation spaceOrientation)
        {
            _transform.SetPositionAndRotation(spaceOrientation.Position, spaceOrientation.Rotation);
        }

        public void Destruct()
        {
            Destructed?.Invoke();
        }
    }
}