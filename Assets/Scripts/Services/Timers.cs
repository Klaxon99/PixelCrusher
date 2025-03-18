using System;
using System.Collections.Generic;
using System.Linq;

public class Timers : ItemUpdatable, ITimer
{
    private List<Timer> _items;

    public Timers(IUpdateService updateService) : base(updateService)
    {
        _items = new List<Timer>();
    }

    public void Create(float time, Action action)
    {
        _items.Add(new Timer(time, action));
    }

    protected override void OnUpdate(float deltaTime)
    {
        foreach (Timer timer in _items.ToList())
        {
            timer.Tick(deltaTime);

            if (timer.IsStoped)
            {
                _items.Remove(timer);
            }
        }
    }

    private class Timer
    {
        private float _accumulatedTime;
        private float _targetTime;
        private Action _action;

        public Timer(float targetTime, Action action)
        {
            _accumulatedTime = 0f;

            if (targetTime < _accumulatedTime)
            {
                throw new InvalidOperationException();
            }

            _targetTime = targetTime;
            _action = action;
        }

        public bool IsStoped => _accumulatedTime >= _targetTime;

        public void Tick(float deltaTime)
        {
            _accumulatedTime += deltaTime;

            if (IsStoped)
            {
                _action.Invoke();
            }
        }
    }
}