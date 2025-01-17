using Assets.Scripts.Presenters;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour, IView
{
    [SerializeField] private Button _pauseButton;

    private IPresenter _presenter;

    public event Action PauseButtonPressed;

    public void Init(IPresenter presenter)
    {
        _presenter = presenter;

        _pauseButton.onClick.AddListener(OnPauseButtonClicked);

        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }

    private void OnPauseButtonClicked()
    {
        PauseButtonPressed?.Invoke();
    }
}