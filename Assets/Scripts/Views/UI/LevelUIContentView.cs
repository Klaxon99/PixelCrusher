using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Views
{
    public class LevelUIContentView : PopUpControlledView
    {
        [SerializeField] private RectTransform _parent;

        private List<LevelUIItem> _contentItems;

        public event Action<int> LevelSelected;

        public RectTransform RectTransform => _parent;

        protected override void OnDisable()
        {
            base.OnDisable();

            foreach (LevelUIItem item in _contentItems)
            {
                item.Clicked -= OnLevelSelected;
            }
        }

        public void SetContent(IEnumerable<LevelUIItem> items)
        {
            _contentItems = new List<LevelUIItem>();

            foreach (LevelUIItem item in items)
            {
                item.Clicked += OnLevelSelected;
                _contentItems.Add(item);
            }
        }

        private void OnLevelSelected(int levelId)
        {
            LevelSelected?.Invoke(levelId);
        }
    }
}