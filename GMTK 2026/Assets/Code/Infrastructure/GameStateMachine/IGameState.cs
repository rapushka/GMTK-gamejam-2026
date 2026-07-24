namespace Core
{
    public interface IGameState
    {
        public void Enter(GameStateMachine stateMachine);
    }

    public interface IUpdateGameState
    {
        public void Update(float deltaTime);
    }
}