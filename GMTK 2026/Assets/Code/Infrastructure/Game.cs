namespace Core
{
    public class Game
    {
        private readonly GameStateMachine _stateMachine;

        public Game()
        {
            _stateMachine = new(
                new InitGameState()
            );
        }

        public void OnGameLoaded()
        {
            _stateMachine.Enter<InitGameState>();
        }
    }
}