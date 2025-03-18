using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class ObjectsPool<T> where T : MonoBehaviour
    {
        private T _prefab;
        private Queue<T> _items;

        public ObjectsPool(T prefab)
        {
            _prefab = prefab ?? throw new ArgumentNullException();
            _items = new Queue<T>();
        }

        public void AddItem(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            item.gameObject.SetActive(false);
            _items.Enqueue(item);
        }

        public T GetItem()
        {
            int minCount = 0;

            if (_items.Count > minCount)
            {
                return _items.Dequeue();
            }
            else
            {
                return GameObject.Instantiate(_prefab);
            }
        }
    }
}