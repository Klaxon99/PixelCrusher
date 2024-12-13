using System;
using UnityEngine;

public class ServiceUpdater : MonoBehaviour, IUpdateService
{
    public event Action<float> Updated;

    private void Update()
    {
        Updated?.Invoke(Time.deltaTime);
    }
}

public class Updater : MonoBehaviour
{
    public void StopAllUpdates()
    {
        StopAllCoroutines();
    }
}