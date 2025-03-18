using System;

namespace Assets.Scripts.Models
{
    public interface IReadOnlyScore
    {
        public event Action<int> CountChanged;

        public int Count { get; }

        public int MaxCount { get; }
    }
}