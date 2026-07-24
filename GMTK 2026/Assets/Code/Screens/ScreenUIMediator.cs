using UnityEngine;

namespace Core
{
    public class ScreenUIMediator : IService
    {
        private static AssetsProvider AssetsProvider => ServiceLocator.Get<AssetsProvider>();
        public GameplayHUD GameplayHUD { get; private set; }
        public void OpenGameplayUI()
        {
            GameplayHUD = Object.Instantiate(AssetsProvider.GameplayHUDPrefab, UiRoot);
        }
    }
}
