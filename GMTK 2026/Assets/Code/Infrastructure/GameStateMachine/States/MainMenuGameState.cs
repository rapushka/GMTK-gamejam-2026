namespace Core
{
    public class MainMenuGameState : IGameState, IExitGameState
    {
        private static UIMediator      UiMediator      => ServiceLocator.Get<UIMediator>();
        
        private GameStateMachine _stateMachine;
        
        public void Enter(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            UiMediator.MainMenu.OnPlayButtonPressed += OnPlayButtonPressed;
            UiMediator.OpenMainMenu();
        }

        private void OnPlayButtonPressed()
        {
            _stateMachine.Enter<StartGameState>();
        }

        public void Exit()
        {
            UiMediator.MainMenu.OnPlayButtonPressed -= OnPlayButtonPressed;
            UiMediator.CloseMainMenu();
        }
    }
}