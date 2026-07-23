using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IGameState> _states;

        private IGameState _currentState;

        public GameStateMachine(params IGameState[] states)
        {
            _states = states.ToDictionary(s => s.GetType());
        }

        public void Enter<TState>()
            where TState : IGameState
        {
            var nextState = _states[typeof(TState)];

            _currentState = nextState;
            _currentState.Enter(this);
        }
    }
}