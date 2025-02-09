using UnityEngine;
using UnityEngine.UI;
using System;
using Assets.Scripts.Presenters;

public class PauseMenuView : PopUpView, IView
{
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private SoundView _soundView;

    private IPresenter _presenter;

    public event Action CloseButtonClicked;
    
    public event Action MainMenuButtonClicked;

    public event Action OpenButtonClicked;

    public void Init(IPresenter presenter)
    {
        _presenter = presenter;

        _closeButton.onClick.AddListener(OnCloseButtonClicked);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        _openButton.onClick.AddListener(OnOpenButtonClicked);

        _presenter.Enable();
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);

        _presenter.Disable();
    }

    private void OnOpenButtonClicked()
    {
        OpenButtonClicked?.Invoke();
    }

    private void OnMainMenuButtonClicked()
    {
        MainMenuButtonClicked?.Invoke();
    }

    private void OnCloseButtonClicked()
    {
        CloseButtonClicked?.Invoke();
    }
}