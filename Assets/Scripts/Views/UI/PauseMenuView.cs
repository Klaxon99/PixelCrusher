using UnityEngine;
using Assets.Scripts.PresentersClone;
using UnityEngine.UI;
using System;

public class PauseMenuView : MonoBehaviour, IView
{
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private SoundView _soundView; 

    private IPresenter _presenter;

    public event Action OpenButtonClicked;

    public event Action CloseButtonClicked;
    
    public event Action MainMenuButtonClicked;

    public event Action SoundSwitchButtonPressed;

    public SoundView SoundView => _soundView;

    public void Init(IPresenter presenter)
    {
        _presenter = presenter;

        _openButton.onClick.AddListener(OnOpenButtonClicked);
        _closeButton.onClick.AddListener(OnCloseButtonClicked);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        _soundView.Clicked += OnSoundButtonPressed;

        _presenter.Enable();
    }

    private void OnDestroy()
    {
        _openButton.onClick.RemoveListener(OnOpenButtonClicked);
        _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
        _soundView.Clicked += OnSoundButtonPressed;

        _presenter.Disable();
    }


    private void OnSoundButtonPressed()
    {
        SoundSwitchButtonPressed?.Invoke();
    }

    private void OnMainMenuButtonClicked()
    {
        MainMenuButtonClicked?.Invoke();
    }

    private void OnCloseButtonClicked()
    {
        CloseButtonClicked?.Invoke();
    }

    private void OnOpenButtonClicked()
    {
        OpenButtonClicked?.Invoke();
    }
}