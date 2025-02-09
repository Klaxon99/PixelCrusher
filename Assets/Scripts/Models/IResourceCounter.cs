using System;

namespace Assets.Scripts.Models
{
    public interface IResourceCounter
    {
        public event Action<int> CountChanged;

        public int Count { get; }
    }
}