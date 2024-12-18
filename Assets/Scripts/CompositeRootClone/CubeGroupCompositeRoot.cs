using Assets.Scripts.FactoriesClone;
using Assets.Scripts.ModelsClone;
using Assets.Scripts.PresentersClone;
using UnityEngine;

namespace Assets.Scripts.CompositeRootClone
{
    public class CubeGroupCompositeRoot : CompositeRoot
    {
        [SerializeField] private CubesForm _cubesForm;
        [SerializeField] private ScoreView _scoreView;

        private CubeGroupFactory _factory;

        public override void Init()
        {
            _cubesForm.Init();
            _factory = new CubeGroupFactory(_cubesForm);
            _factory.Create(new CubeGroup(_cubesForm.ItemsPositions));
            Score score = new Score(_cubesForm.ItemsCount);
            _scoreView.Init(new ScorePresenter(score, _scoreView));
        }
    }
}