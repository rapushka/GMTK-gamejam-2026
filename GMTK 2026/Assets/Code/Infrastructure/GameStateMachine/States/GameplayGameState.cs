namespace Core
{
    public class GameplayGameState : IGameState, IUpdateGameState
    {
        private static CalendarSystem     CalendarSystem     => ServiceLocator.Get<CalendarSystem>();
        private static LivesSystem        LivesSystem        => ServiceLocator.Get<LivesSystem>();
        private static PeopleArriveSystem PeopleArriveSystem => ServiceLocator.Get<PeopleArriveSystem>();

        public void Enter(GameStateMachine stateMachine) { }

        public void Update(float deltaTime)
        {
            CalendarSystem.OnUpdate();
            PeopleArriveSystem.OnUpdate(deltaTime);

            if (LivesSystem.AreAllLivesLost)
            {
                // TODO: GAME OVER
            }
        }
    }
}