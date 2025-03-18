using System;

public interface IUpdateService
{
    event Action<float> Updated;
}