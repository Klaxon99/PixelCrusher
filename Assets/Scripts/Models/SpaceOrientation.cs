using UnityEngine;

namespace Assets.Scripts.Models
{
    public struct SpaceOrientation
    {
        public SpaceOrientation(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public Quaternion Rotation { get; }
        public Vector3 Position { get; }
    }
}
