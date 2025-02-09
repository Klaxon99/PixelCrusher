using Assets.Scripts.Factories;

namespace Assets.Scripts.Models
{
    public class DynamicMovementImprovement : GunImprovement
    {
        public override string Title => "DynamicMovement";

        public override void Improve(GunBuilder gunBuilder)
        {
            gunBuilder.AddDynamicMovement();
        }
    }
}