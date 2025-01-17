using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelUIItemView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _contentImage;
    [SerializeField] private TMP_Text _contentText;
    [SerializeField] private Image _lockImage;

    private Level _level;

    public event Action<Level> Clicked;

    public bool IsActive { get; private set; }

    public void Init(Level level, bool isActive)
    {
        _level = level;
        _contentImage.sprite = level.Image;
        _contentText.text = level.SceneName;
        IsActive = isActive;

        _lockImage.gameObject.SetActive(!IsActive);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke(_level);
    }
}