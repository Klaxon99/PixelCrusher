using System;

namespace Assets.Scripts.ModelsClone
{
    public class GameSound
    {
        private readonly SoundSettings _soundSettings;

        public GameSound(SoundSettings soundSettings)
        {
            _soundSettings = soundSettings;
        }

        public event Action Muted;

        public event Action Unmuted;

        public bool IsMuted => _soundSettings.IsMute;

        public void SwitchVolume()
        {
            _soundSettings.IsMute = !_soundSettings.IsMute;

            if (_soundSettings.IsMute)
            {
                Muted?.Invoke();
            }
            else
            {
                Unmuted?.Invoke();
            }
        }
    }
}