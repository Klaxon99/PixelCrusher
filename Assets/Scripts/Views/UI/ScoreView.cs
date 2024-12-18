using Assets.Scripts.PresentersClone;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreCountText;
    [SerializeField] private Image _progressBar;

    private IPresenter _presenter;

    public event Action<Collider> CollisionEntered;

    public void Init(IPresenter presenter)
    {
        _presenter = presenter;

        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }

    private void OnTriggerEnter(Collider collider)
    {
        CollisionEntered?.Invoke(collider);
    }

    public void SetScoreText(int count)
    {
        _scoreCountText.text = count.ToString();
    }

    public void SetProgressBar(float progressPercent)
    {
        _progressBar.fillAmount = progressPercent;
    }
}