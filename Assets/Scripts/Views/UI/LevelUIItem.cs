using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelUIItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _contentImage;
    [SerializeField] private Image _lockImage;

    private int _levelId;

    public event Action<int> Clicked;

    public bool IsActive { get; private set; }

    public void Init(int levelId, Sprite image, bool isActive)
    {
        _levelId = levelId;
        _contentImage.sprite = image;
        IsActive = isActive;
        
        _lockImage.gameObject.SetActive(!IsActive);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke(_levelId);
    }
}