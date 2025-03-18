using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Projectile
    {
        public readonly float InteractionRadius;
        public readonly float InteractionForce;

        private readonly float _speed;

        public Projectile(Quaternion startRotation, float speed, float interactionRadius, float interactionForce)
        {
            _speed = speed;
            InteractionRadius = interactionRadius;
            InteractionForce = interactionForce;
            Rotation = startRotation;
        }

        public Quaternion Rotation { get; private set; }

        public Vector3 Velocity => Rotation * Vector3.forward * _speed;

        public event Action VelocityChanged;

        public void Reflect(Vector3 normal)
        {
            Vector3 up = Rotation * Vector3.up;
            Vector3 correctNormal = Vector3.ProjectOnPlane(normal, up);
            Vector3 reflect = Vector3.Reflect(Velocity.normalized, correctNormal);

            Rotation = Quaternion.LookRotation(reflect, up);

            VelocityChanged?.Invoke();
        }
    }
}