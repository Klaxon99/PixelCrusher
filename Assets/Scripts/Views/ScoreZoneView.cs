using System;
using UnityEngine;

namespace Assets.Scripts.Views
{
    public class ScoreZoneView : View
    {
        [field : SerializeField] public AudioSource CoinSound { get; private set; }

        public event Action<Collider> CollisionEntered;

        private void OnTriggerEnter(Collider collider)
        {
            CollisionEntered?.Invoke(collider);
        }
    }
}