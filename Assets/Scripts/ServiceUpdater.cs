using System;
using UnityEngine;

public class ServiceUpdater : MonoBehaviour, IUpdateService
{
    public event Action<float> Updated;

    public event Action Disabled;

    private void Update()
    {
        Updated?.Invoke(Time.deltaTime);
    }

    private void OnDisable()
    {
        Disabled?.Invoke();
    }
}