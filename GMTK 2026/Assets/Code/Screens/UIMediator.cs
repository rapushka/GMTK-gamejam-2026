using UnityEngine;

namespace Core
{
    public class UIMediator : IService
    {
        private static AssetsProvider AssetsProvider => ServiceLocator.Get<AssetsProvider>();
        private static UiRoot         UiRoot         => ServiceLocator.Get<UiRoot>();

        public GameplayHUD GameplayHUD { get; private set; }

        public void OpenGameplayUI()
        {
            GameplayHUD = Object.Instantiate(AssetsProvider.GameplayHUDPrefab, UiRoot.Transform);
        }
    }
}