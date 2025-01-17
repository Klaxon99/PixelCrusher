using Assets.Scripts.Presenters;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
public class CubeGroupView : MonoBehaviour, IView, ICubeGroup
{
    private Transform _transform;
    private Rigidbody _rigidbody;
    private RigidbodyConstraints _constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    private IPresenter _presenter;

    public event Action<CubeGroupItemView> ItemDetached;

    public void Init(IPresenter presenter)
    {
        _transform = transform;
        _presenter = presenter;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = _constraints;

        presenter.Enable();
    }

    public void SetChilds(IEnumerable<CubeGroupItemView> items)
    {
        foreach (CubeGroupItemView item in items)
        {
            _rigidbody.mass++;

            item.SetParentGroup(this, _transform);
        }
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }

    public void Detach(CubeGroupItemView cubeGroupItemView)
    {
        ItemDetached?.Invoke(cubeGroupItemView);
    }
}