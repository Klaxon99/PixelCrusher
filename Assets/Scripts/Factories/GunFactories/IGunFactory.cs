using Assets.Scripts.Models;

namespace Assets.Scripts.Factories
{
    public interface IGunFactory
    {
        GunView Create(SpaceOrientation spaceOrientation);
    }
}