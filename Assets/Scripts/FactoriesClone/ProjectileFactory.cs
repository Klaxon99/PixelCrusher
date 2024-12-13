﻿using Assets.Scripts.ModelsClone;
using Assets.Scripts.PresentersClone;
using UnityEngine;

namespace Assets.Scripts.FactoriesClone
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly ObjectsPool<ProjectileView> _pool;
        private readonly ProjectileSettings _projectileSettings;

        public ProjectileFactory(ProjectileSettings projectileSettings)
        {
            _projectileSettings = projectileSettings;
            _pool = new ObjectsPool<ProjectileView>(_projectileSettings.ProjectilePrefab);
        }

        public ProjectileView Create(SpaceOrientation spaceOrientation)
        {
            Projectile model = new Projectile(spaceOrientation.Rotation * Vector3.forward, _projectileSettings.Speed);
            ProjectileView view = _pool.GetItem();

            view.SetOrientation(spaceOrientation);
            view.gameObject.SetActive(true);
            
            new ProjectilePresenter(model, view, this, _projectileSettings);

            return view;
        }

        public void Destroy(ProjectileView projectileView)
        {
            _pool.AddItem(projectileView);
        }
    }
}