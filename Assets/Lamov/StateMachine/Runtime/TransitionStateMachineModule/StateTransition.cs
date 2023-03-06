using System;
using Lamov.StateMachine.Runtime.States;

namespace Lamov.StateMachine.Runtime.TransitionStateMachineModule
{
    public class StateTransition
    {
        public IState TargetState { get; }
        private readonly Func<bool>[] _predicates;

        public StateTransition(IState targetState, params Func<bool>[] predicates)
        {
            TargetState = targetState;
            _predicates = predicates;
        }

        public bool IsPredicateComplete()
        {
            foreach (var predicate in _predicates)
            {
                if (predicate.Invoke()) continue;
                
                return false;
            }

            return true;
        }
    }
}