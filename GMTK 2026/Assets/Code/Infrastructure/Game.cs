namespace Core
{
    public class Game
    {
        private static InputController InputController => ServiceLocator.Get<InputController>();

        private readonly GameStateMachine _stateMachine = new(
            new InitGameState()
        );

        public void OnGameLoaded()
        {
            _stateMachine.Enter<InitGameState>();
        }

        public void OnUpdate()
        {
            InputController.OnUpdate();
        }
    }
}