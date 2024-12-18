using UnityEngine;

namespace Assets.Scripts.CompositeRootClone
{
    public class LevelSceneCompositeRoot : MonoBehaviour
    {
        [SerializeField] private GunCompositeRoot _gunCompositeRoot;
        [SerializeField] private CubeGroupCompositeRoot _cubeGroupCompositeRoot;
        [SerializeField] private Bounds _levelBounds;

        private void Awake()
        {
            _levelBounds.Init();
            _cubeGroupCompositeRoot.Init();
            _gunCompositeRoot.Init();
        }
    }
}