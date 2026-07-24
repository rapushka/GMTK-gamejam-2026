namespace Core
{
    public class Game
    {
        private static InputSystem InputSystem => ServiceLocator.Get<InputSystem>();

        private readonly GameStateMachine _stateMachine = new(
            new StartGameState()
        );

        public void OnGameLoaded()
        {
            // TODO: Main Menu and stuff
            _stateMachine.Enter<StartGameState>();
        }

        public void OnUpdate()
        {
            InputSystem.OnUpdate();
        }
    }
}