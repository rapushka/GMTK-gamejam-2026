namespace Core
{
    public class InitGameState : IGameState
    {
        public void Enter(GameStateMachine stateMachine)
        {
            UnityEngine.Debug.Log("You're in Init Game State!");
        }
    }
}