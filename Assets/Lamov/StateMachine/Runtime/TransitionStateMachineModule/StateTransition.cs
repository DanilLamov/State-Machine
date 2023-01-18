using System;

namespace Lamov.StateMachine.Runtime.TransitionStateMachineModule
{
    public class StateTransition
    {
        public bool IsPredicateComplete => _predicate.Invoke();
        
        private Func<bool> _predicate;
        
        public StateTransition(Func<bool> predicate)
        {
            _predicate = predicate;
        }
    }
}