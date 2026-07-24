using UnityEngine;

namespace Core
{
    public class ScreensMediator : IService
    {
        private static AssetsProvider AssetsProvider => ServiceLocator.Get<AssetsProvider>();

        public GameScreen GameScreen { get; private set; }

        public void OpenGameplayScreen()
        {
            GameScreen = Object.Instantiate(AssetsProvider.GameScreenPrefab);
        }
    }
}