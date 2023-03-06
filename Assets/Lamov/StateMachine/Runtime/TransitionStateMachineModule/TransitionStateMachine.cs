using System.Collections.Generic;
using Lamov.StateMachine.Runtime.States;
using Lamov.StateMachine.Runtime.UpdateStateMachineModule;

namespace Lamov.StateMachine.Runtime.TransitionStateMachineModule
{
    public class TransitionStateMachine : UpdateStateMachine
    {
        public Dictionary<IState, List<StateTransition>> _transitions;

        public TransitionStateMachine()
        {
            _transitions = new Dictionary<IState, List<StateTransition>>();
        }

        public void AddTransition<TState>(TState startState, StateTransition stateTransition) where TState : class, IState
        {
            if (_transitions.ContainsKey(startState))
            {
                _transitions[startState].Add(stateTransition);
            }
            else
            {
                _transitions.Add(startState, new List<StateTransition>() { stateTransition });
            }
        }

        public void AddTransitions<TState>(TState startState, params StateTransition[] stateTransitions) where TState : class, IState
        {
            if (_transitions.ContainsKey(startState))
            {
                _transitions[startState].AddRange(stateTransitions);
            }
            else
            {
                _transitions.Add(startState, new List<StateTransition>(stateTransitions));
            }
        }

        public override void Update()
        {
            if (_transitions.TryGetValue(ActiveState, out List<StateTransition> transitions))
            {
                foreach (var transition in transitions)
                {
                    if (transition.IsPredicateComplete())
                    {
                        Enter(transition.TargetState);
                        break;
                    }
                }
            }

            base.Update();
        }
    }
}