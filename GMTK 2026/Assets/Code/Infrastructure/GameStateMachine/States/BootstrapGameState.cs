namespace Core
{
    public class BootstrapGameState : IGameState
    {
        private static ScreensMediator ScreensMediator => ServiceLocator.Get<ScreensMediator>();
        private static UIMediator      UiMediator      => ServiceLocator.Get<UIMediator>();
        private static AudioPlayer     AudioPlayer     => ServiceLocator.Get<AudioPlayer>();

        public void Enter(GameStateMachine stateMachine)
        {
            UiMediator.Initialize();
            ScreensMediator.Initialize();
            AudioPlayer.Init();

            stateMachine.Enter<MainMenuGameState>();
        }
    }
}