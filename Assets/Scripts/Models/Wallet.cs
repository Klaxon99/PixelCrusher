using System;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Wallet : IReadOnlyWallet
    {
        public Wallet(int money = 0)
        {
            Money = money;
        }

        public event Action<int> MoneyCountChanged;

        public int Money { get; private set; }

        public void Add(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Money += amount;

            MoneyCountChanged?.Invoke(Money);
        }

        public void Reduce(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (amount > Money)
            {
                throw new InvalidOperationException();
            }

            Money -= amount;

            MoneyCountChanged?.Invoke(Money);
        }
    }
}