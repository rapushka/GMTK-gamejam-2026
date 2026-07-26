using UnityEngine;

namespace Core
{
    public class Game
    {
        private static UIMediator  UIMediator  => ServiceLocator.Get<UIMediator>();

        private readonly GameStateMachine _stateMachine = new(
            new BootstrapGameState(),
            new MainMenuGameState(),
            new StartGameState(),
            new GameplayGameState(),
            new LoseGameState()
        );

        public void OnGameLoaded()
        {
            _stateMachine.Enter<BootstrapGameState>();
        }

        public void OnUpdate()
        {
            var deltaTime = Time.deltaTime;
            
            _stateMachine.OnUpdate(deltaTime);
        }
    }
}