using Lamov.StateMachine.Runtime.States;
using Lamov.StateMachine.Runtime.UpdateStateMachineModule;

namespace Lamov.StateMachine.Runtime.SubStateMachines
{
    public class UpdateSubStateMachine : SimpleSubStateMachine<UpdateStateMachine>, IUpdateState
    {
        public void Update() => _stateMachine.Update();
    }
}