using System;
using UnityEngine;

public class ServiceFixedUpdater : MonoBehaviour, IUpdateService
{
    public event Action<float> Updated;

    public event Action Disabled;

    private void FixedUpdate()
    {
        Updated?.Invoke(Time.fixedDeltaTime);
    }

    private void OnDisable()
    {
        Disabled?.Invoke();
    }
}