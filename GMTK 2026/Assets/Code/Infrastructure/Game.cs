using UnityEngine;

namespace Core
{
    public class Game
    {
        private static InputSystem InputSystem => ServiceLocator.Get<InputSystem>();
        private static UIMediator UIMediator => ServiceLocator.Get<UIMediator>();

        private readonly GameStateMachine _stateMachine = new(
            new BootstrapGameState(),
            new MainMenuGameState(),
            new StartGameState(),
            new GameplayGameState()
        );

        public void OnGameLoaded()
        {
            _stateMachine.Enter<BootstrapGameState>();
        }

        public void OnUpdate()
        {
            var deltaTime = Time.deltaTime;

            InputSystem.OnUpdate();

            _stateMachine.OnUpdate(deltaTime);
        }
    }
}