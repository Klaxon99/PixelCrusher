using Assets.Scripts.Factories;
using System;

namespace Assets.Scripts.Models
{
    [Serializable]
    public abstract class GunImprovement
    {
        public abstract string Title { get; }

        public abstract void Improve(GunBuilder gunBuilder);
    }
}