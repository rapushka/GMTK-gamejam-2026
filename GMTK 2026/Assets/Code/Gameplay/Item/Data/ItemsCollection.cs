using System;
using System.Linq;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class ItemsCollection
    {
        [SerializeField] private ItemConfig[] _itemConfigs;

        public ItemConfig GetTmp() => _itemConfigs[0];

        public ItemConfig GetItem(ItemKey key) => _itemConfigs.First(c => c.Key == key);
    }
}