using Assets.Scripts.Models;

namespace Assets.Scripts.Factories
{
    public interface IGunInitializer
    {
        public void SetShootControlSystem(IShootControlSystem shootControlSystem);

        public void SetMovement(IGunMovement gunMovement);
    }
}