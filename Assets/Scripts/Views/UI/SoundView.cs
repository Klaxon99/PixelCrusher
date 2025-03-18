using System;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Assets.Scripts.Views
{
    public class SoundView : View, IPointerClickHandler
    {
        [SerializeField] private SoundSwitcher _soundSwitcher;

        public event Action Clicked;

        public void OnPointerClick(PointerEventData eventData) => Clicked?.Invoke();

        public void Mute() => _soundSwitcher.Mute();

        public void Unmute() => _soundSwitcher.Unmute();
    }
}