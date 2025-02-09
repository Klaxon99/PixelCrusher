using Assets.Scripts.Factories;

namespace Assets.Scripts.Models
{
    public class BurstShootSystemImprovement : GunImprovement
    {
        public override string Title => "BurstShootSystem";

        public override void Improve(GunBuilder gunBuilder)
        {
            gunBuilder.AddBurstShootingSystem();
        }
    }
}