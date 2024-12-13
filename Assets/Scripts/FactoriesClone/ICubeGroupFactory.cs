using Assets.Scripts.ModelsClone;

namespace Assets.Scripts.FactoriesClone
{
    public interface ICubeGroupFactory
    {
        public CubeGroupView Create(CubeGroup view);

        public void Destruct(CubeGroupView cubeGroupView);
    }
}