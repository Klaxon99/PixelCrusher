using Assets.Scripts.Presenters;
using System;
using UnityEngine;

public class ScoreZoneView : MonoBehaviour, IView
{
    private IPresenter _presenter;

    public event Action<Collider> CollisionEntered;

    public void Init(IPresenter presenter)
    {
        _presenter = presenter;

        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }

    private void OnTriggerEnter(Collider collider)
    {
        CollisionEntered?.Invoke(collider);
    }
}