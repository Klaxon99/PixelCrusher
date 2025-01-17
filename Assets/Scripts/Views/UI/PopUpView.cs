using UnityEngine;

public abstract class PopUpView : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    public void Show() => _canvas.enabled = true;

    public void Hide() => _canvas.enabled = false;
}