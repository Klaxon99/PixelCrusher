using Assets.Scripts.Presenters;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Views
{
    [RequireComponent(typeof(Transform))]
    [RequireComponent(typeof(Rigidbody))]
    public class CubeGroupView : View, ICubeGroup
    {
        private Transform _transform;
        private Rigidbody _rigidbody;
        private RigidbodyConstraints _constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;

        public event Action<CubeGroupItem> ItemDetached;

        public override void Init(IPresenter presenter)
        {
            base.Init(presenter);
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.constraints = _constraints;
        }

        public void SetChilds(IEnumerable<CubeGroupItem> items)
        {
            foreach (CubeGroupItem item in items)
            {
                _rigidbody.mass++;

                item.SetParentGroup(this, _transform);
            }
        }

        public void Detach(CubeGroupItem cubeGroupItemView)
        {
            ItemDetached?.Invoke(cubeGroupItemView);
        }
    }
}