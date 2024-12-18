using Assets.Scripts.ModelsClone;

namespace Assets.Scripts.FactoriesClone
{
    public class GunFactory
    {
        private readonly GunView _prefab;

        public GunFactory(GunView prefab) => _prefab = prefab;


    }
}