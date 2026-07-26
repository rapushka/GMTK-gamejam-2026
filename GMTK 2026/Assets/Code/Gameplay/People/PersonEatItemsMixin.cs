using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core
{
    public class PersonEatItemsMixin
    {
        private static ItemsContainer ItemsContainer => ServiceLocator.Get<ItemsContainer>();
        private static AssetsProvider AssetsProvider => ServiceLocator.Get<AssetsProvider>();

        public async UniTask EatItems(PersonComponent person)
        {
            if (!ItemsContainer.HasAnyFood)
                return;

            var thoughtKey = ItemsContainer.PickRandomUniqueKey();
            var itemSprite = GetItemSprite(thoughtKey);

            var bubble = Object.Instantiate(AssetsProvider.BubblePrefab, person.BubblePivot);
            bubble.transform.localPosition = Vector3.zero;

            await bubble.Appear(itemSprite);

            var item = ItemsContainer.FindByKey(thoughtKey);
            if (item != null)
                ItemsContainer.Eat(item);

            await bubble.Disappear();
        }

        private static Sprite GetItemSprite(ItemKey key)
        {
            var config = AssetsProvider.Items.GetItem(key);
            return config.ItemPrefab2D.GetComponentInChildren<SpriteRenderer>().sprite;
        }
    }
}
