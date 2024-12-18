using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundSettings", menuName = "Settings/SoundSettings", order = 51)]
public class SoundSettings : ScriptableObject, ISoundSwitcher
{
    [SerializeField, Range(0, 100)] private int _currentVolume;

    private int _prevVolume;

    public event Action<int> VolumeChange;

    public event Action Muted;

    public event Action Unmuted;

    public int MinVolume { get; } = 0;

    public int MaxVolume { get; } = 100;

    public bool IsMute => _currentVolume == MinVolume;

    public void Mute()
    {
        if (IsMute)
        {
            throw new InvalidOperationException();
        }

        _prevVolume = _currentVolume;

        SetVolume(MinVolume);

        Muted?.Invoke();
    }

    public void Unmute()
    {
        if (IsMute == false)
        {
            throw new InvalidOperationException();
        }

        SetVolume(_prevVolume);

        Unmuted?.Invoke();
    }

    public void SetVolume(int value)
    {
        if (value < MinVolume || value > MaxVolume)
        {
            throw new InvalidOperationException();
        }

        _currentVolume = value;

        VolumeChange?.Invoke(value);
    }
}