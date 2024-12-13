using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoundView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _soundImage;
    [SerializeField] private Sprite _enableSoundIcon;
    [SerializeField] private Sprite _disableSoundIcon;

    public event Action Clicked;

    public void SetEnabledIcon()
    {
        _soundImage.sprite = _enableSoundIcon;
    }

    public void SetDisabledIcon()
    {
        _soundImage.sprite = _disableSoundIcon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke();
    }
}