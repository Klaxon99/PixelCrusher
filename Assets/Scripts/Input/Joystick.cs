using UnityEngine;

public class Joystick : MonoBehaviour
{
    [field: SerializeField] public RectTransform JoystickBackground;

    [field: SerializeField] public RectTransform Stick;

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);
}