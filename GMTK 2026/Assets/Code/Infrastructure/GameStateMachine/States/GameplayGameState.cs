namespace Core
{
    public class GameplayGameState : IGameState, IUpdateGameState
    {
        private static CalendarSystem CalendarSystem => ServiceLocator.Get<CalendarSystem>();

        public void Enter(GameStateMachine stateMachine) { }

        public void Update(float deltaTime)
        {
            CalendarSystem.OnUpdate();
        }
    }
}