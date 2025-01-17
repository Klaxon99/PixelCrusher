using Assets.Scripts.Models;

namespace Assets.Scripts.Factories
{
    public interface IProjectileFactory
    {
        ProjectileView Create(SpaceOrientation spaceOrientation);

        void Destroy(ProjectileView projectileView);
    }
}