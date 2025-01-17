using Assets.Scripts.Presenters;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class LevelUIContentView : PopUpView, IView
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _openButton;
    [SerializeField] private RectTransform _parent;

    private List<LevelUIItemView> _contentItems;
    private IPresenter _presenter;

    public event Action<Level> LevelSelected;

    public event Action CloseButtonClicked;

    public event Action OpenButtonClicked;

    public RectTransform RectTransform => _parent;

    public void Init(IPresenter presenter)
    {
        _presenter = presenter;

        _presenter.Enable();
        _closeButton.onClick.AddListener(OnCloseButtonClicked);
        _openButton.onClick.AddListener(OnOpenButtonClicked);
    }

    private void OnDisable()
    {
        foreach (LevelUIItemView item in _contentItems)
        {
            item.Clicked -= OnLevelSelected;
        }

        _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
        _openButton.onClick.RemoveListener(OnOpenButtonClicked);

        _presenter.Disable();
    }

    public void SetContent(IEnumerable<LevelUIItemView> items)
    {
        _contentItems = new List<LevelUIItemView>();

        foreach (LevelUIItemView item in items)
        {
            if (item.IsActive)
            {
                item.Clicked += OnLevelSelected;
                _contentItems.Add(item);
            }
        }
    }

    private void OnOpenButtonClicked()
    {
        OpenButtonClicked?.Invoke();
    }

    private void OnCloseButtonClicked()
    {
        CloseButtonClicked?.Invoke();
    }

    private void OnLevelSelected(Level level)
    {
        LevelSelected?.Invoke(level);
    }
}