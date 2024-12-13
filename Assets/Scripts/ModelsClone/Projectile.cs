using System;
using UnityEngine;

namespace Assets.Scripts.ModelsClone
{
    public class Projectile
    {
        private readonly float _speed;

        public Projectile(Vector3 startDirection, float speed)
        {
            _speed = speed;
            Velocity = startDirection.normalized * _speed;
        }

        public Vector3 Velocity { get; private set; }

        public event Action VelocityChanged;

        public void Reflect(Vector3 normal)
        {
            Velocity = Vector3.Reflect(Velocity, normal).normalized * _speed;

            VelocityChanged?.Invoke();
        }
    }
}