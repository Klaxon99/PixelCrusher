using UnityEngine;

[CreateAssetMenu(fileName = "BaseGunSettings", menuName = "Settings/BaseGunSettings", order = 51)]
public class GunBaseSettings : ScriptableObject
{
    [field : SerializeField] public float Speed { get; private set; }
    [field : SerializeField] public float ReloadTime { get; private set; }
    [field : SerializeField] public float MaxStrafe { get; private set; }
    [field : SerializeField] public GunView GunPrefab { get; private set; }
}