using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    [Serializable]
    public class ItemsCollection
    {
        [SerializeField] private ItemConfig[] _itemConfigs;

        public ItemConfig GetRandom()
        {
            var randomIndex = Random.Range(0, _itemConfigs.Length);
            return _itemConfigs[randomIndex];
        }

        public ItemConfig GetItem(ItemKey key) => _itemConfigs.First(c => c.Key == key);
    }
}