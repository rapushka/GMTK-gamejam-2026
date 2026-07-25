namespace Core
{
    public class GameplayGameState : IGameState, IUpdateGameState
    {
        private static CalendarSystem CalendarSystem => ServiceLocator.Get<CalendarSystem>();
        private static LivesSystem    LivesSystem    => ServiceLocator.Get<LivesSystem>();

        public void Enter(GameStateMachine stateMachine) { }

        public void Update(float deltaTime)
        {
            CalendarSystem.OnUpdate();

            if (LivesSystem.AreAllLivesLost)
            {
                // TODO: GAME OVER
            }
        }
    }
}