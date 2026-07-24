namespace Core
{
    public class ItemSpawnSystem : IService
    {
        private static AssetsProvider AssetsProvider => ServiceLocator.Get<AssetsProvider>();

        public void OnGameStart()
        {
            var prefab = AssetsProvider.PlaceholderItemPrefab;
        }
    }
}