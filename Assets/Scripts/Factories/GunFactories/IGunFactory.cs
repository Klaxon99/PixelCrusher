using Assets.Scripts.Models;
using Assets.Scripts.Views;

namespace Assets.Scripts.Factories
{
    public interface IGunFactory
    {
        GunView Create(SpaceOrientation spaceOrientation, int gunLevel);
    }
}