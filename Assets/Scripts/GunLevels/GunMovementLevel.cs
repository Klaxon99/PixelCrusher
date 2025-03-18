using Assets.Scripts.Factories;
using Assets.Scripts.Models;
using UnityEngine;

[CreateAssetMenu(fileName = "GunMovementLevel", menuName = "UIContent/GunMovementLevel")]
public class GunMovementLevel : GunLevel
{
    [field: SerializeField] public float Speed { get; private set; }

    public override void Improve(IGunInitializer gunInitializer)
    {
        gunInitializer.SetMovement(new GunDynamicMovement(Speed));
    }
}