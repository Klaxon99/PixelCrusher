﻿using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSwitcher : MonoBehaviour
{
    private const string GlobalVolume = "GlobalVolume";
    private const float MinVolume = -50f;
    private const float MaxVolume = 20f;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Image _soundImage;
    [SerializeField] private Sprite _enableSoundIcon;
    [SerializeField] private Sprite _disableSoundIcon;

    public void Mute()
    {
        _audioMixer.SetFloat(GlobalVolume, MinVolume);
        _soundImage.sprite = _disableSoundIcon;
    }

    public void Unmute()
    {
        _audioMixer.SetFloat(GlobalVolume, MaxVolume);
        _soundImage.sprite = _enableSoundIcon;
    }
}