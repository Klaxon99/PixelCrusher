using Assets.Scripts.ModelsClone;
using Assets.Scripts.PresentersClone;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class LevelUIContentView : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _openButton;
    [SerializeField] private RectTransform _parent;

    private List<LevelUIItemView> _contentItems;
    private IPresenter _presenter;

    public event Action<Levels> LevelSelected;

    public event Action CloseButtonClicked;

    public event Action OpenButtonClicked;

    public RectTransform RectTransform => _parent;

    public void Init(IPresenter presenter, IEnumerable<LevelUIItemView> contentItems)
    {
        _presenter = presenter;
        _contentItems = new List<LevelUIItemView>();

        foreach (LevelUIItemView item in contentItems)
        {
            if (item.IsActive)
            {
                item.Clicked += OnLevelSelected;
                _contentItems.Add(item);
            }
        }

        _presenter.Enable();
        _closeButton.onClick.AddListener(OnCloseButtonClicked);
        _openButton.onClick.AddListener(OnOpenButtonClicked);
    }

    private void OnDestroy()
    {
        foreach (LevelUIItemView item in _contentItems)
        {
            item.Clicked -= OnLevelSelected;
        }

        _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
        _openButton.onClick.RemoveListener(OnOpenButtonClicked);

        _presenter.Disable();
    }

    private void OnOpenButtonClicked()
    {
        OpenButtonClicked?.Invoke();
    }

    private void OnCloseButtonClicked()
    {
        CloseButtonClicked?.Invoke();
    }

    private void OnLevelSelected(Levels level)
    {
        LevelSelected?.Invoke(level);
    }
}