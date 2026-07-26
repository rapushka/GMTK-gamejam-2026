namespace Core
{
    public class GameplayGameState : IGameState, IUpdateGameState, IExitGameState
    {
        private static CalendarSystem     CalendarSystem     => ServiceLocator.Get<CalendarSystem>();
        private static LivesSystem        LivesSystem        => ServiceLocator.Get<LivesSystem>();
        private static PeopleArriveSystem PeopleArriveSystem => ServiceLocator.Get<PeopleArriveSystem>();
        private static UIMediator         UIMediator         => ServiceLocator.Get<UIMediator>();
        private static AudioPlayer        AudioPlayer        => ServiceLocator.Get<AudioPlayer>();
        private static InputSystem InputSystem => ServiceLocator.Get<InputSystem>();

        private GameStateMachine _stateMachine;
        private bool _isPaused;

        public void Enter(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            
            UIMediator.GameplayHUD.OnTutorialButtonClicked += TutorialButtonClicked;
            UIMediator.TutorialPopup.OnCloseButtonClicked += TutorialCloseButtonClicked;
            
            AudioPlayer.PlayMusicGameplay();
            
            if (!UIMediator.TutorialPopup.IsTutorialShownInitial)
            {
                _isPaused = true;
                UIMediator.TutorialPopup.ShowInitial();
            }
        }

        public void Update(float deltaTime)
        {
            if(_isPaused)
                return;
            
            InputSystem.OnUpdate();
            CalendarSystem.OnUpdate();
            PeopleArriveSystem.OnUpdate(deltaTime);

            if (LivesSystem.AreAllLivesLost)
            {
                _stateMachine.Enter<LoseGameState>();
            }
        }

        public void Exit()
        { 
            UIMediator.GameplayHUD.OnTutorialButtonClicked -= TutorialButtonClicked;
            UIMediator.TutorialPopup.OnCloseButtonClicked -= TutorialCloseButtonClicked;
        }
        
        private void TutorialButtonClicked()
        {
            _isPaused = true;

            UIMediator.TutorialPopup.Show();
        }

        private void TutorialCloseButtonClicked()
        {
            UIMediator.TutorialPopup.Hide();
            _isPaused = false;
        }
    }
}