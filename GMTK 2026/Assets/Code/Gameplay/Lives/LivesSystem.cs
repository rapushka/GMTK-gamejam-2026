namespace Core
{
    public class LivesSystem : IService
    {
        private static UIMediator UIMediator => ServiceLocator.Get<UIMediator>();

        private int _totalLives;
        private int _currentLives;

        public bool AreAllLivesLost => LivesCounterUI.AreAllLivesLost;

        private static LivesCounterUI LivesCounterUI => UIMediator.GameplayHUD.LivesCounter;

        public void Init()
        {
            LivesCounterUI.Init();
        }

        public void LooseALife()
        {
            LivesCounterUI.LooseALife();
        }
    }
}