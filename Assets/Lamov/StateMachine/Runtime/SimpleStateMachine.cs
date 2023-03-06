using System;
using System.Collections.Generic;
using Lamov.StateMachine.Runtime.States;

namespace Lamov.StateMachine.Runtime
{
    public class SimpleStateMachine
    {
        public IState ActiveState { get; protected set; }
        
        protected Dictionary<Type, IState> _states;

        public SimpleStateMachine()
        {
            _states = new Dictionary<Type, IState>();
        }
    
        public void AddState<TState>(TState state) where TState : class, IState
        {
            _states.Add(state.GetType(), state);
        }
    
        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();

            if (state is IStateEnter enterState) enterState.OnStateEnter();
        }

        public void Enter<TState>(TState newActiveState) where TState : class, IState
        {
            var state = ChangeState(newActiveState);

            if (state is IStateEnter enterState) enterState.OnStateEnter();
        }

        private TState ChangeState<TState>() where TState : class, IState => ChangeState(GetState<TState>());

        private TState ChangeState<TState>(TState newActiveState) where TState : class, IState
        {
            if (ActiveState is IStateExit exitState) exitState.OnStateExit();
            
            ActiveState = newActiveState;
            return newActiveState;
        }

        private TState GetState<TState>() where TState : class, IState => _states[typeof(TState)] as TState;
    }
}
