using Assets.Scripts.ModelsClone;
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

    public event Action<Levels> Clicked;

    public Levels Level {  get; private set; }

    public bool IsActive { get; private set; }

    public void Init(Sprite image, string text, Levels level, bool isActive)
    {
        _contentImage.sprite = image;
        _contentText.text = text;
        Level = level;
        IsActive = isActive;

        _lockImage.gameObject.SetActive(!IsActive);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke(Level);
    }
}