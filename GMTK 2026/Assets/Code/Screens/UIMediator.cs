using UnityEngine;

namespace Core
{
    public class UIMediator : IService
    {
        private static AssetsProvider AssetsProvider => ServiceLocator.Get<AssetsProvider>();
        private static UiRoot         UiRoot         => ServiceLocator.Get<UiRoot>();

        public GameplayHUD GameplayHUD { get; private set; }
        public MainMenu MainMenu { get; private set; }

        public void Initialize()
        {
            GameplayHUD = Object.Instantiate(AssetsProvider.GameplayHUDPrefab, UiRoot.Transform);
            GameplayHUD.gameObject.SetActive(false);
            
            MainMenu = Object.Instantiate(AssetsProvider.MainMenuPrefab, UiRoot.Transform);
            MainMenu.gameObject.SetActive(false);
        }
        
        public void OpenGameplayUI()
        {
            GameplayHUD.gameObject.SetActive(true);
        }

        public void OpenMainMenu()
        {
            MainMenu.gameObject.SetActive(true);
        }

        public void CloseMainMenu()
        {
            MainMenu.gameObject.SetActive(false);
        }
    }
}