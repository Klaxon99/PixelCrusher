using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.FactoriesClone
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
            if (_items.Count > 0)
            {
                return _items.Dequeue();
            }

            T item = GameObject.Instantiate(_prefab);
            item.gameObject.SetActive(false);

            return item;
        }
    }
}