namespace Core
{
    public class BootstrapGameState : IGameState
    {
        private static ScreensMediator ScreensMediator => ServiceLocator.Get<ScreensMediator>();
        private static UIMediator      UiMediator      => ServiceLocator.Get<UIMediator>();
        public void Enter(GameStateMachine stateMachine)
        {
            UiMediator.Initialize();
            ScreensMediator.Initialize();
            stateMachine.Enter<MainMenuGameState>();
        }
    }
}