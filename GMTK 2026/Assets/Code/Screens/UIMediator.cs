using UnityEngine;

namespace Core
{
    public class UIMediator : IService
    {
        private static AssetsProvider AssetsProvider => ServiceLocator.Get<AssetsProvider>();
        public GameplayHUD GameplayHUD { get; private set; }
        public void OpenGameplayUI()
        {
            GameplayHUD = Object.Instantiate(AssetsProvider.GameplayHUDPrefab, ServiceLocator.Get<UiRoot>().transform);
        }
    }
}
