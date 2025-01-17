using Assets.Scripts.Models;
using Assets.Scripts.Presenters;
using UnityEngine;

namespace Assets.Scripts.Factories
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
            ProjectileView view = _pool.GetItem();
            view.gameObject.SetActive(true);
            view.SetOrientation(spaceOrientation);
            view.SetVelocityDirection(spaceOrientation.Rotation * Vector3.forward);
            view.SetSpeed(_projectileSettings.Speed);
            ProjectilePresenter projectilePresenter = new ProjectilePresenter(view, this, _projectileSettings);

            view.Init(projectilePresenter);

            return view;
        }

        public void Destroy(ProjectileView projectileView)
        {
            _pool.AddItem(projectileView);
        }
    }
}