using Assets.Scripts.Models;
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

        public int ItemsCount => _items.Count;

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
            T item;

            if (_items.Count > 0)
            {
                item = _items.Dequeue();
            }
            else
            {
                item = GameObject.Instantiate(_prefab);
            }

            return item;
        }
    }
}