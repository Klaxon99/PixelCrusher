using Assets.Scripts.ModelsClone;
using UnityEngine;

public class GunView : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _gunTurret;
    [SerializeField] private Transform _gunBody;
    [SerializeField] private AudioSource _shootSound;

    public Transform ShootPoint => _shootPoint;

    public AudioSource ShootSound => _shootSound;

    public void SetOrientation(SpaceOrientation spaceOrientation)
    {
        _gunBody.position = spaceOrientation.Position;
        _gunTurret.rotation = spaceOrientation.Rotation;
    }    
}