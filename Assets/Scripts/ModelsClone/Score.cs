using System;

namespace Assets.Scripts.ModelsClone
{
    public class Score
    {
        private int _minCount;

        public Score(int maxCount)
        {
            _minCount = 0;

            if (maxCount <= _minCount)
            {
                throw new InvalidOperationException();
            }

            Count = _minCount;
            MaxCount = maxCount;
        }

        public event Action<int> CountChanged;

        public int Count { get; private set; }

        public int MaxCount { get; private set; }

        public void Add()
        {
            Count++;

            if (Count > MaxCount)
            {
                throw new InvalidOperationException();
            }

            CountChanged?.Invoke(Count);
        }
    }
}