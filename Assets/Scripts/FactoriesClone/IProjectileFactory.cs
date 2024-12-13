using Assets.Scripts.ModelsClone;

namespace Assets.Scripts.FactoriesClone
{
    public interface IProjectileFactory
    {
        ProjectileView Create(SpaceOrientation spaceOrientation);

        void Destroy(ProjectileView projectileView);
    }
}