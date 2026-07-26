using UnityEngine;

namespace Core
{
    public class ItemSpawnSystem : IService
    {
        private static AssetsProvider  AssetsProvider  => ServiceLocator.Get<AssetsProvider>();
        private static ScreensMediator ScreensMediator => ServiceLocator.Get<ScreensMediator>();
        private static ItemsContainer  ItemsContainer  => ServiceLocator.Get<ItemsContainer>();
        private static BalanceConfig   BalanceConfig   => ServiceLocator.Get<BalanceConfig>();

        public void SpawnStartItems()
        {
            var fridge = ScreensMediator.GameScreen.Fridge;
            var foodCount = BalanceConfig.FoodInFridgeOnStart.GetRandom();

            for (var i = 0; i < foodCount; i++)
            {
                var item = CreateItem();
                var position = fridge.CreateRandomPosition(item);

                item.WorldPosition = position;
            }
        }

        public Item CreateItem()
        {
            var config = AssetsProvider.Items.GetRandom();
            var itemPrefab = config.ItemPrefab2D;

            var item = Object.Instantiate(itemPrefab);
            item.Init(config);

            ItemsContainer.AddItem(item);
            return item;
        }
    }
}