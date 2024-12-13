using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Timers : Update
{
    private List<Timer> _items;

    public Timers(IUpdateService updateService) : base(updateService)
    {
        _items = new List<Timer>();
        Enable();
    }

    public void AddItem(float time, Action action)
    {
        _items.Add(new Timer(time, action));
    }

    protected override void OnUpdate(float deltaTime)
    {
        bool needClear = false;

        foreach (Timer timer in _items)
        {
            timer.Tick(deltaTime);

            if (timer.IsStoped)
            {
                needClear = true;
            }
        }

        _items = needClear ? _items.Where(timer => timer.IsStoped == false).ToList() : _items;
    }

    private class Timer
    {
        private float _accumulatedTime;
        private float _targetTime;
        private Action _action;

        public Timer(float targetTime, Action action)
        {
            _accumulatedTime = 0f;

            if (targetTime <= _accumulatedTime)
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