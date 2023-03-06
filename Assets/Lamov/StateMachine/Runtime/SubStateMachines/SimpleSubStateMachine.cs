using Lamov.StateMachine.Runtime.States;

namespace Lamov.StateMachine.Runtime.SubStateMachines
{
    public class SimpleSubStateMachine<TStateMachine> : IState where TStateMachine : SimpleStateMachine, new()
    {
        protected TStateMachine _stateMachine;
        
        public SimpleSubStateMachine()
        {
            _stateMachine = new TStateMachine();
        }
    }
}