using System;

public interface ITimer
{
    public void Create(float time, Action action);
}
