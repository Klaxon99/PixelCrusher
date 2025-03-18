using Assets.Scripts.Models;
using Assets.Scripts.Presenters;
using Assets.Scripts.Views;

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
            Projectile projectile = new Projectile(spaceOrientation.Rotation, 
                _projectileSettings.Speed,
                _projectileSettings.InteractionRadius, 
                _projectileSettings.InteractionForce);

            ProjectileView view = _pool.GetItem();
            view.gameObject.SetActive(true);
            view.SetOrientation(spaceOrientation);
            view.SetVelocity(projectile.Velocity);
            ProjectilePresenter projectilePresenter = new ProjectilePresenter(projectile, view, this);

            view.Init(projectilePresenter);

            return view;
        }

        public void Destroy(ProjectileView projectileView)
        {
            _pool.AddItem(projectileView);
        }
    }
}