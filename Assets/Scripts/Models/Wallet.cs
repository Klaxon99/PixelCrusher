using System;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Wallet : IResourceCounter
    {
        public Wallet(int count)
        {
            Count = count;
        }

        public event Action<int> CountChanged;

        public int Count { get; private set; }

        public void Add(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Count += amount;

            CountChanged?.Invoke(Count);
        }

        public void Reduce(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (amount > Count)
            {
                throw new InvalidOperationException();
            }

            Count -= amount;

            CountChanged?.Invoke(Count);
        }
    }
}