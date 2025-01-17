using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundSettings", menuName = "Settings/SoundSettings", order = 51)]
public class SoundSettings : ScriptableObject
{
    [field : SerializeField] public bool IsMute { get; private set; }

    public event Action Muted;

    public event Action Unmuted;

    public void SwitchState()
    {
        IsMute = !IsMute;

        if (IsMute)
        {
            Muted?.Invoke();
        }
        else
        {
            Unmuted?.Invoke();
        }
    }
}