using UnityEngine;

namespace Core
{
    public class ItemSpawnSystem : IService
    {
        private static AssetsProvider  AssetsProvider  => ServiceLocator.Get<AssetsProvider>();
        private static ScreensMediator ScreensMediator => ServiceLocator.Get<ScreensMediator>();

        public void OnGameStart()
        {
            var itemPrefab = AssetsProvider.PlaceholderItemPrefab;
            var gameScreen = ScreensMediator.GameScreen;

            var shelves = gameScreen.Fridge.Shelves;
            foreach (var shelf in shelves)
            {
                var itemsPerShelf = Random.Range(1, 3);
                for (var i = 0; i < itemsPerShelf; i++)
                {
                    var item = Object.Instantiate(itemPrefab);
                    var pointOnShelf = shelf.CreateRandomPoint();
                    item.WorldPosition = shelf.ClampItem(pointOnShelf, item.Bounds);
                }
            }
        }
    }
}