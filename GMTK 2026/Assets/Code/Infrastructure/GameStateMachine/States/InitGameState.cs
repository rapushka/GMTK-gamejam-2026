using UnityEngine;

namespace Core
{
    public class InitGameState : IGameState
    {
        private static AssetsProvider AssetsProvider => ServiceLocator.Get<AssetsProvider>();

        public void Enter(GameStateMachine stateMachine)
        {
            var gameScreen = Object.Instantiate(AssetsProvider.GameScreenPrefab);
        }
    }
}