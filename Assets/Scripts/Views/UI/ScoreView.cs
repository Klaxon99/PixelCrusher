using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreCountText;
    [SerializeField] private Image _progressBar;

    public void SetScoreText(int count)
    {
        _scoreCountText.text = count.ToString();
    }

    public void SetProgressBar(float progressPercent)
    {
        _progressBar.fillAmount = progressPercent;
    }
}