using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent (typeof(LineRenderer))]
[RequireComponent(typeof(Transform))]
public class MovementTrack : MonoBehaviour
{
    [SerializeField] private int _linePointsCount;
    [SerializeField] private float _startWidth;
    [SerializeField] private float _endWidth;
    [SerializeField] private Gradient _gradient;

    private LineRenderer _lineRenderer;
    private LinkedList<Vector3> _linePoints;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _lineRenderer = GetComponent<LineRenderer> ();
        _linePoints = new LinkedList<Vector3>();
        _lineRenderer.colorGradient = _gradient;
        _lineRenderer.startWidth = _startWidth;
        _lineRenderer.endWidth = _endWidth;
        _lineRenderer.positionCount = 0;
    }

    private void OnDisable()
    {
        _linePoints.Clear();
        _lineRenderer.positionCount = 0;
    }

    private void FixedUpdate()
    {
        _linePoints.AddFirst(_transform.position);

        if (_linePoints.Count > _linePointsCount)
        {
            _linePoints.RemoveLast();
        }

        _lineRenderer.positionCount = _linePoints.Count;
        _lineRenderer.SetPositions(_linePoints.ToArray());
    }
}