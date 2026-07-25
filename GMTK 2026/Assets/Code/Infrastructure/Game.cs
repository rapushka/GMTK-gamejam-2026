using UnityEngine;

namespace Core
{
    public class Game
    {
        private static InputSystem InputSystem => ServiceLocator.Get<InputSystem>();

        private readonly GameStateMachine _stateMachine = new(
            new BootstrapGameState(),
            new StartGameState(),
            new GameplayGameState()
        );

        public void OnGameLoaded()
        {
            // TODO: Main Menu and stuff
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