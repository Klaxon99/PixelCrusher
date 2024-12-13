using UnityEngine;

public class EndGameScreenView : MonoBehaviour
{
    [SerializeField] private Canvas _endGameCanvas;

    public void Show()
    {
        _endGameCanvas.gameObject.SetActive(true);
    }
}