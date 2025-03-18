using Assets.Scripts.Factories;
using Assets.Scripts.Models;
using UnityEngine;

[CreateAssetMenu(fileName = "GunStartLevel", menuName = "UIContent/GunStartLevel")]
public class GunStartLevel : GunLevel
{
    public override void Improve(IGunInitializer gunInitializer)
    {
        gunInitializer.SetMovement(new GunBaseMovement());
        gunInitializer.SetShootControlSystem(new GunBaseShootSystem(3f));
    }
}