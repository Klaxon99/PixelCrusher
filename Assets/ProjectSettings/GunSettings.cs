using UnityEngine;

[CreateAssetMenu(fileName = "GunSettings", menuName = "Settings/GunSettings", order = 51)]
public class GunSettings : ScriptableObject
{
    [SerializeField] private GunView _gunPrefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _reloadTime;

    public float Speed => _speed;

    public float ReloadTime => _reloadTime;

    public GunView GunPrefab => _gunPrefab;
}