using Assets.Scripts.Presenters;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundView : MonoBehaviour, IView, IPointerClickHandler
{
    [SerializeField] private SoundSwitcher _soundSwitcher;

    private IPresenter _presenter;

    public event Action Clicked;

    public void Init(IPresenter presenter)
    {
        _presenter = presenter;

        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }

    public void Mute()
    {
        _soundSwitcher.Mute();
    }

    public void Unmute()
    {
        _soundSwitcher.Unmute();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke();
    }
}