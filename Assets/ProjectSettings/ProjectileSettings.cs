using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSettings", menuName = "Settings/ProjectileSettings", order = 51)]
public class ProjectileSettings : ScriptableObject
{
    [SerializeField] private ProjectileView _projectilePrefab; 
    [SerializeField] private float _interactionRadius;
    [SerializeField] private float _interactionForce;
    [SerializeField] private float _speed;

    public ProjectileView ProjectilePrefab => _projectilePrefab;

    public float InteractionRadius => _interactionRadius;

    public float InteractionForce => _interactionForce;

    public float Speed => _speed;
}