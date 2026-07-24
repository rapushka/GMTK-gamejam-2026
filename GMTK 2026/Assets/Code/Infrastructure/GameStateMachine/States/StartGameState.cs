using UnityEngine;

namespace Core
{
    public class StartGameState : IGameState
    {
        private static AssetsProvider  AssetsProvider  => ServiceLocator.Get<AssetsProvider>();
        private static ItemSpawnSystem ItemSpawnSystem => ServiceLocator.Get<ItemSpawnSystem>();

        public void Enter(GameStateMachine stateMachine)
        {
            var gameScreen = Object.Instantiate(AssetsProvider.GameScreenPrefab);

            ItemSpawnSystem.OnGameStart();
        }
    }
}