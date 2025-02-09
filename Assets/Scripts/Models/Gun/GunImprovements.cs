using Assets.Scripts.Factories;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Models
{
    public class GunImprovements
    {
        private Dictionary<string, GunImprovement> _items;

        public IEnumerable<GunImprovement> Items => _items.Values;

        public void AddImprovement(GunImprovement improvement)
        {
            if (_items.ContainsKey(improvement.Title))
            {
                throw new InvalidOperationException();
            }

            _items[improvement.Title] = improvement;
        }

        public void Improve(GunBuilder gunBuilder)
        {
            foreach (GunImprovement item in _items.Values)
            {
                item.Improve(gunBuilder);
            }
        }
    }
}