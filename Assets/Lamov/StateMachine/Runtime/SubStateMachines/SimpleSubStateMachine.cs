using Lamov.StateMachine.Runtime.States;

namespace Lamov.StateMachine.Runtime.SubStateMachines
{
    public class SimpleSubStateMachine<TStateMachine> : IState, IStateExit where TStateMachine : SimpleStateMachine, new()
    {
        protected TStateMachine _stateMachine;
        
        public SimpleSubStateMachine()
        {
            _stateMachine = new TStateMachine();
        }

        public void OnStateExit()
        {
            if (_stateMachine.ActiveState is IStateExit exitState) exitState.OnStateExit();
        }
    }
}