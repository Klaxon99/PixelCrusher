using Assets.Scripts.Views;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSettings", menuName = "Settings/ProjectileSettings", order = 51)]
public class ProjectileSettings : ScriptableObject
{
    [field : SerializeField] public ProjectileView ProjectilePrefab { get; private set; }

    [field : SerializeField] public float InteractionRadius { get; private set; }

    [field: SerializeField] public float InteractionForce { get; private set; }

    [field: SerializeField] public float Speed {  get; private set; }
}