using TMPro;
using UnityEngine;

public class ValueView : View
{
    [SerializeField] private TMP_Text _text;

    public void SetTextValue(string value)
    {
        _text.text = value;
    }
}