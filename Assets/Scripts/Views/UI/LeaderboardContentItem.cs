using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views
{
    public class LeaderboardContentItem : MonoBehaviour
    {
        [SerializeField] private Image _avatar;
        [SerializeField] private TMP_Text _score;
        [SerializeField] private TMP_Text _nickname;
        [SerializeField] private TMP_Text _position;

        public void Init(Sprite sprite, string nickname, int score, int position)
        {
            _avatar.sprite = sprite;
            _nickname.text = nickname;
            _score.text = score.ToString();
            _position.text = position.ToString();
        }
    }
}