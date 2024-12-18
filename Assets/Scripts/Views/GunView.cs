using Assets.Scripts.ModelsClone;
using Assets.Scripts.PresentersClone;
using UnityEngine;

public class GunView : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _gunTurret;
    [SerializeField] private Transform _gunBody;
    [SerializeField] private AudioSource _shootSound;

    private IPresenter _presenter;

    public Transform ShootPoint => _shootPoint;

    public AudioSource ShootSound => _shootSound;

    public void Init(IPresenter presenter, SpaceOrientation spaceOrientation)
    {
        SetOrientation(spaceOrientation);
        _presenter = presenter;
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }

    public void SetOrientation(SpaceOrientation spaceOrientation)
    {
        _gunBody.position = spaceOrientation.Position;
        _gunTurret.rotation = spaceOrientation.Rotation;
    }    
}