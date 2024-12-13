using System;

namespace Assets.Scripts.ModelsClone
{
    public class SoundSwitcher : ISoundSwitcher
    {
        private readonly SoundSettings _soundSettings;

        public SoundSwitcher(SoundSettings soundSettings)
        {
            _soundSettings = soundSettings;
        }

        public event Action Muted;

        public event Action Unmuted;

        public void Mute()
        {

        }

        public void Unmute()
        {

        }
    }
}