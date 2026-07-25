using UnityEngine;

namespace Core
{
    public class MainMenuGameState : IGameState, IExitGameState
    {
        private static UIMediator      UiMediator      => ServiceLocator.Get<UIMediator>();
        
        private GameStateMachine _stateMachine;
        
        public void Enter(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            UiMediator.MainMenu.Initialize();
            UiMediator.MainMenu.OnPlayButtonPressed += OnPlayButtonPressed;
            UiMediator.MainMenu.OnExitButtonPressed += OnExitButtonPressed;
            UiMediator.OpenMainMenu();
        }

        private void OnPlayButtonPressed()
        {
            _stateMachine.Enter<StartGameState>();
        }

        private void OnExitButtonPressed()
        {
            Debug.Log("Game Exit");
            Application.Quit();
        }

        public void Exit()
        {
            UiMediator.MainMenu.OnPlayButtonPressed -= OnPlayButtonPressed;
            UiMediator.MainMenu.OnExitButtonPressed -= OnExitButtonPressed;
            UiMediator.CloseMainMenu();
        }
    }
}