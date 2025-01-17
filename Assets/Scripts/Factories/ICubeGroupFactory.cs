using Assets.Scripts.Models;

namespace Assets.Scripts.Factories
{
    public interface ICubeGroupFactory
    {
        public CubeGroupView Create(CubeGroup view);

        public void Destruct(CubeGroupView cubeGroupView);
    }
}