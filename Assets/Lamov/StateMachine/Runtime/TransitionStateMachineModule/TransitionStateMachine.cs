using System;
using System.Collections.Generic;
using Lamov.StateMachine.Runtime.UpdateStateMachineModule;
using Lamov.StateMachine.States;

namespace Lamov.StateMachine.Runtime.TransitionStateMachineModule
{
    public class TransitionStateMachine : UpdateStateMachine
    {
        public Dictionary<Type, List<StateTransition>> _transitions;

        public TransitionStateMachine()
        {
            _transitions = new Dictionary<Type, List<StateTransition>>();
        }

        public void AddTransition<TState>(StateTransition stateTransition) where TState : class, IState
        {
            var type = typeof(TState);
            if (_transitions.ContainsKey(type))
            {
                _transitions[type].Add(stateTransition);
            }
            else
            {
                _transitions.Add(type, new List<StateTransition>() { stateTransition });
            }
        }

        public void AddTransitions<TState>(params StateTransition[] stateTransitions) where TState : class, IState
        {
            var type = typeof(TState);
            if (_transitions.ContainsKey(type))
            {
                _transitions[type].AddRange(stateTransitions);
            }
            else
            {
                _transitions.Add(type, new List<StateTransition>(stateTransitions));
            }
        }

        public override void Update()
        {
            foreach (var (type, transitions) in _transitions)
            {
                if (TransitionsCompleted(transitions))
                {
                    Enter(type);
                    break;
                }
            }
            
            base.Update();
        }
        
        protected void Enter(Type type)
        {
            if (_activeState is IStateExit exitState) exitState.OnStateExit();
            _activeState = _states[type];
            if (_activeState is IStateEnter enterState) enterState.OnStateEnter();
        }

        private bool TransitionsCompleted(List<StateTransition> stateTransitions)
        {
            foreach (var stateTransition in stateTransitions)
            {
                if (!stateTransition.IsPredicateComplete) return false;
            }

            return true;
        }
    }
}