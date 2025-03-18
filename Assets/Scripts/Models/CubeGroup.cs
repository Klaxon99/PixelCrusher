using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class CubeGroup
    {
        private const int GridStep = 1;

        private HashSet<Vector2> _cubeMap;

        public CubeGroup(IEnumerable<Vector2> items)
        {
            _cubeMap = new HashSet<Vector2>(items);
        }

        public event Action Emptied;

        public event Action<IEnumerable<Vector2>> Splited;

        public IEnumerable<Vector2> Items => _cubeMap;

        public void Remove(Vector2 cubePosition)
        {
            if (_cubeMap.Contains(cubePosition) == false)
            {
                throw new InvalidOperationException();
            }

            _cubeMap.Remove(cubePosition);

            if (_cubeMap.Count == 0)
            {
                Emptied?.Invoke();
                return;
            }

            CheckSplit();
        }

        private void CheckSplit()
        {
            Vector2 firstPosition = _cubeMap.First();

            HashSet<Vector2> touchedItems = new HashSet<Vector2>();

            SearchNeighbours(firstPosition, touchedItems, _cubeMap);

            if (_cubeMap.Count > 0)
            {
                Splited?.Invoke(touchedItems);
            }
            else
            {
                _cubeMap = touchedItems;
            }
        }

        private void SearchNeighbours(Vector2 currentPosition, HashSet<Vector2> touchedPosition, HashSet<Vector2> targetPositions)
        {
            if (targetPositions.Contains(currentPosition) == false)
            {
                return; 
            }

            if (touchedPosition.Contains(currentPosition))
            {
                return;
            }

            touchedPosition.Add(currentPosition);
            targetPositions.Remove(currentPosition);

            SearchNeighbours(new Vector2(currentPosition.x + GridStep, currentPosition.y), touchedPosition, targetPositions);
            SearchNeighbours(new Vector2(currentPosition.x, currentPosition.y + GridStep), touchedPosition, targetPositions);
            SearchNeighbours(new Vector2(currentPosition.x - GridStep, currentPosition.y), touchedPosition, targetPositions);
            SearchNeighbours(new Vector2(currentPosition.x, currentPosition.y - GridStep), touchedPosition, targetPositions);
        }
    }
}