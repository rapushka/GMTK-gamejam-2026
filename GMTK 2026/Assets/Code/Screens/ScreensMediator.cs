using UnityEngine;

namespace Core
{
    public class ScreensMediator : IService
    {
        private static AssetsProvider AssetsProvider => ServiceLocator.Get<AssetsProvider>();

        public GameScreen GameScreen { get; private set; }

        public void Initialize()
        {
            GameScreen = Object.Instantiate(AssetsProvider.GameScreenPrefab);
            GameScreen.gameObject.SetActive(false);
        }

        public void OpenGameplayScreen()
        {
            GameScreen.gameObject.SetActive(true);
        }
    }
}