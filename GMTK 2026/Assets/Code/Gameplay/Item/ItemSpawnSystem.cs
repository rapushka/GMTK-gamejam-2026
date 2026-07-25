using UnityEngine;

namespace Core
{
    public class ItemSpawnSystem : IService
    {
        private static AssetsProvider  AssetsProvider  => ServiceLocator.Get<AssetsProvider>();
        private static ScreensMediator ScreensMediator => ServiceLocator.Get<ScreensMediator>();
        private static ItemsContainer  ItemsContainer  => ServiceLocator.Get<ItemsContainer>();

        public void SpawnStartItems()
        {
            ItemsContainer.DestroyAllItems();
            
            var gameScreen = ScreensMediator.GameScreen;

            var shelves = gameScreen.Fridge.Shelves;
            foreach (var shelf in shelves)
            {
                var itemsPerShelf = Random.Range(1, 3);
                for (var i = 0; i < itemsPerShelf; i++)
                {
                    var config = AssetsProvider.Items.GetRandom();
                    var itemPrefab = config.ItemPrefab2D;

                    var item = Object.Instantiate(itemPrefab);
                    item.Init(config);
                    var pointOnShelf = shelf.CreateRandomPoint();
                    item.WorldPosition = shelf.ClampItem(pointOnShelf, item.Bounds);

                    ItemsContainer.AddItem(item);
                }
            }
        }
    }
}