using Assets.Scripts.Models;
using Assets.Scripts.Views;
using UnityEngine;

public class LeaderboardItemsFactory : ScriptableObject
{
    [SerializeField] private LeaderboardContentItem _prefab;

    public LeaderboardContentItem Create(RectTransform parent, LeaderboardItem leaderboardItem)
    {
        LeaderboardContentItem leaderboardContentItem = Instantiate(_prefab, parent);

        leaderboardContentItem.Init(leaderboardItem.Image, leaderboardItem.Nickname, leaderboardItem.Score, leaderboardItem.Position);

        return leaderboardContentItem;
    }
}