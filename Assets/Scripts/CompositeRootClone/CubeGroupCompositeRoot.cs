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
        [SerializeField] private ScoreZoneView _scoreZoneView;
        [SerializeField] private EndGameScreenView _endGameScreenView;

        private CubeGroupFactory _factory;
        private Score _score;

        public override void Init()
        {
            _cubesForm.Init();
            _factory = new CubeGroupFactory(_cubesForm);
            _factory.Create(new CubeGroup(_cubesForm.ItemsPositions));
            _score = new Score(_cubesForm.ItemsCount);
            new ScorePresenter(_score, _scoreView, _scoreZoneView, _endGameScreenView);
        }
    }
}