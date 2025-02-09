using UnityEngine;
using UnityEngine.UI;

public class ScoreView : ValueView
{
    [SerializeField] private Image _progressBar;

    public void SetProgressBar(float progressPercent)
    {
        _progressBar.fillAmount = progressPercent;
    }
}