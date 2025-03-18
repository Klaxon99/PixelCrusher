using Assets.Scripts.Models;
using Assets.Scripts.Presenters;
using UnityEngine;

namespace Assets.Scripts.Views
{
    [RequireComponent(typeof(LineRenderer))]
    public class GunView : View
    {
        private const float AimLength = 10f;

        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Transform _gunTurret;
        [SerializeField] private Transform _gunBody;
        [SerializeField] private AudioSource _shootSound;

        private LineRenderer _lineRenderer;

        public Transform ShootPoint => _shootPoint;

        public AudioSource ShootSound => _shootSound;

        public override void Init(IPresenter presenter)
        {
            base.Init(presenter);

            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.enabled = true;
        }

        public virtual void SetOrientation(SpaceOrientation spaceOrientation)
        {
            _gunBody.position = spaceOrientation.Position;
            _gunTurret.rotation = spaceOrientation.Rotation;
            _lineRenderer.SetPositions(new Vector3[] { ShootPoint.position, ShootPoint.position + ShootPoint.forward * AimLength });
        }
    }
}