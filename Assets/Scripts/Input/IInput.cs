using System;

public interface IInput : ITransformActions
{
    public event Action ShootKeyPressed;
}