namespace Core
{
    public class StartGameState : IGameState
    {
        private static ScreensMediator ScreensMediator => ServiceLocator.Get<ScreensMediator>();
        private static ItemSpawnSystem ItemSpawnSystem => ServiceLocator.Get<ItemSpawnSystem>();
        private static UIMediator UiMediator => ServiceLocator.Get<UIMediator>();
        public void Enter(GameStateMachine stateMachine)
        {
            ScreensMediator.OpenGameplayScreen();
            UiMediator.OpenGameplayUI();
            ItemSpawnSystem.OnGameStart();
        }
    }
}