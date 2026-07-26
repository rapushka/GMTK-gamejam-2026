namespace Core
{
    public class LoseGameState : IGameState, IExitGameState
    {
        private static UIMediator UiMediator => ServiceLocator.Get<UIMediator>();
        private GameStateMachine _stateMachine;

        public void Enter(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            UiMediator.LosePopup.OnMenuButtonClicked += BackToMainMenu;
            UiMediator.LosePopup.OnRestartButtonClicked += RestartGame;
            UiMediator.LosePopup.Show();
        }

        private void RestartGame()
        {
            _stateMachine.Enter<StartGameState>();
        }

        private void BackToMainMenu()
        {
            _stateMachine.Enter<MainMenuGameState>();
        }

        public void Exit()
        {
            UiMediator.LosePopup.OnMenuButtonClicked -= BackToMainMenu;
            UiMediator.LosePopup.OnRestartButtonClicked -= RestartGame;
            UiMediator.LosePopup.Hide();
        }
    }
}