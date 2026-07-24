namespace Core
{
    public class StartGameState : IGameState
    {
        private static ScreensMediator ScreensMediator => ServiceLocator.Get<ScreensMediator>();
        private static ItemSpawnSystem ItemSpawnSystem => ServiceLocator.Get<ItemSpawnSystem>();

        public void Enter(GameStateMachine stateMachine)
        {
            ScreensMediator.OpenGameplayScreen();

            ItemSpawnSystem.OnGameStart();
        }
    }
}