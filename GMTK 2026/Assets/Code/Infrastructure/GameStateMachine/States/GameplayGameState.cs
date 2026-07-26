namespace Core
{
    public class GameplayGameState : IGameState, IUpdateGameState
    {
        private static CalendarSystem     CalendarSystem     => ServiceLocator.Get<CalendarSystem>();
        private static LivesSystem        LivesSystem        => ServiceLocator.Get<LivesSystem>();
        private static PeopleArriveSystem PeopleArriveSystem => ServiceLocator.Get<PeopleArriveSystem>();
        private static AudioPlayer        AudioPlayer        => ServiceLocator.Get<AudioPlayer>();

        private GameStateMachine _stateMachine;

        public void Enter(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;

            AudioPlayer.PlayMusicGameplay();
        }

        public void Update(float deltaTime)
        {
            CalendarSystem.OnUpdate();
            PeopleArriveSystem.OnUpdate(deltaTime);

            if (LivesSystem.AreAllLivesLost)
            {
                _stateMachine.Enter<LoseGameState>();
            }
        }
    }
}