﻿using Assets.Scripts.PresentersClone;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundView : MonoBehaviour, IView, IPointerClickHandler
{
    [SerializeField] private SoundSwitcher _soundSwitcher;

    private IPresenter _presenter;

    public event Action Muted;

    public event Action Unmuted;

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

        Muted?.Invoke();
    }

    public void Unmute()
    {
        _soundSwitcher.Unmute();

        Unmuted?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke();
    }
}