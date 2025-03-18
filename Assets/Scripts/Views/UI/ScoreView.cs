using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views
{
    public class ScoreView : ValueView
    {
        [SerializeField] private Image _progressBar;

        public void SetProgressBar(float progressPercent)
        {
            _progressBar.fillAmount = progressPercent;
        }
    }
}