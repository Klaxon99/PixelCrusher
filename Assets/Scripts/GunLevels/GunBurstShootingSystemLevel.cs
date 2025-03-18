using Assets.Scripts.Factories;
using Assets.Scripts.Models;
using UnityEngine;

[CreateAssetMenu(fileName = "GunBurstShootingSystemLevel", menuName = "UIContent/GunBurstShootingSystemLevel")]
public class GunBurstShootingSystemLevel : GunShootingSystemLevel
{
    [field: SerializeField] public int QueueLength;

    public override void Improve(IGunInitializer gunInitializer)
    {
        gunInitializer.SetShootControlSystem(new BurstShootingSystem(ReloadTime, QueueLength));
    }
}