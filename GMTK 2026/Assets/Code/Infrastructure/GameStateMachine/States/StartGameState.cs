namespace Core
{
    public class StartGameState : IGameState
    {
        private static ScreensMediator ScreensMediator => ServiceLocator.Get<ScreensMediator>();
        private static ItemSpawnSystem ItemSpawnSystem => ServiceLocator.Get<ItemSpawnSystem>();
        private static UIMediator      UiMediator      => ServiceLocator.Get<UIMediator>();
        private static CalendarSystem  CalendarSystem  => ServiceLocator.Get<CalendarSystem>();
        private static LivesSystem     LivesSystem     => ServiceLocator.Get<LivesSystem>();

        public void Enter(GameStateMachine stateMachine)
        {
            ScreensMediator.OpenGameplayScreen();
            UiMediator.OpenGameplayUI();

            CalendarSystem.Init();
            ItemSpawnSystem.SpawnStartItems();
            LivesSystem.Init();

            stateMachine.Enter<GameplayGameState>();
        }
    }
}