using System;

namespace Assets.Scripts.Models
{
    public class GunLevelImprover
    {
        public GunLevelImprover(IGunLevelInfo currentLevel)
        {
            CurrentLevel = currentLevel;
        }

        public event Action Improved;

        public IGunLevelInfo CurrentLevel { get; private set; }

        public IGunLevelInfo NextLevel => CurrentLevel.NextLevel;

        public bool CanImprove(IReadOnlyWallet wallet)
        {
            if (NextLevel == null)
            {
                return false;
            }

            if (wallet.Money < NextLevel.Price)
            {
                return false;
            }

            return true;
        }

        public void Improve(IReadOnlyWallet wallet)
        {
            if (CanImprove(wallet) == true)
            {
                CurrentLevel = NextLevel;

                Improved?.Invoke();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}