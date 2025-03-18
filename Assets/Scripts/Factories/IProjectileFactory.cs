using Assets.Scripts.Models;
using Assets.Scripts.Views;

namespace Assets.Scripts.Factories
{
    public interface IProjectileFactory
    {
        ProjectileView Create(SpaceOrientation spaceOrientation);

        void Destroy(ProjectileView projectileView);
    }
}