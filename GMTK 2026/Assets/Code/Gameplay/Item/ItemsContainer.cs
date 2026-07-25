using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public class ItemsContainer : IService
    {
        private static CalendarSystem CalendarSystem => ServiceLocator.Get<CalendarSystem>();
        private static LivesSystem    LivesSystem    => ServiceLocator.Get<LivesSystem>();

        private readonly List<Item> _items = new();

        public bool HasAnyFood => _items.Any();

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void Eat(Item item)
        {
            var wasSpoiled = !CalendarSystem.IsGoodToEat(item);
            Object.Destroy(item.gameObject);
            // TODO: vfx+sfx?

            if (wasSpoiled)
                LivesSystem.LooseALife();

            _items.Remove(item);
        }

        public void ThrowInTrash(Item item)
        {
            var wasSpoiled = CalendarSystem.IsGoodToThrowAway(item);
            Object.Destroy(item.gameObject);

            if (!wasSpoiled)
                LivesSystem.LooseALife();

            _items.Remove(item);
        }

        public Item PickRandom()
        {
            var randomIndex = Random.Range(0, _items.Count);
            return _items[randomIndex];
        }

        public void DestroyAllItems()
        {
            if(_items.Count == 0)
                return;

            foreach (var item in _items)
            {
                Object.Destroy(item.gameObject);
            }
            
            _items.Clear();
        }
    }
}