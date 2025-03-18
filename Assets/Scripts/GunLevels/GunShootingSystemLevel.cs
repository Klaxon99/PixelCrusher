using Assets.Scripts.Factories;
using Assets.Scripts.Models;
using UnityEngine;

[CreateAssetMenu(fileName = "GunShootSystemLevel", menuName = "UIContent/GunShootSystemLevel")]
public class GunShootingSystemLevel : GunLevel
{
    [field : SerializeField] public float ReloadTime { get; private set; }

    public override void Improve(IGunInitializer gunInitializer)
    {
        gunInitializer.SetShootControlSystem(new GunBaseShootSystem(ReloadTime));
    }
}