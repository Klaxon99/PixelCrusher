using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSwitcher : MonoBehaviour
{
    private const string GlobalVolume = "GlobalVolume";
    private const float MinVolume = -80f;
    private const float MaxVolume = 0f;

    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private Image _soundImage;
    [SerializeField] private Sprite _enableSoundIcon;
    [SerializeField] private Sprite _disableSoundIcon;

    public void Mute()
    {
        _mixerGroup.audioMixer.SetFloat(GlobalVolume, MinVolume);
        _soundImage.sprite = _disableSoundIcon;
    }

    public void Unmute()
    {
        _mixerGroup.audioMixer.SetFloat(GlobalVolume, MaxVolume);
        _soundImage.sprite = _enableSoundIcon;
    }
}