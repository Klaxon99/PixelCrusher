using System;

public interface ISoundSwitcher
{
    public event Action Muted;

    public event Action Unmuted;

    public void Mute();

    public void Unmute();
}