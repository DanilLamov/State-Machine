using Lamov.StateMachine.Runtime.States;
using Lamov.StateMachine.Runtime.UpdateStateMachineModule;

namespace Lamov.StateMachine.Runtime.SubStateMachines
{
    public class UpdateSubStateMachine : SimpleSubStateMachine<UpdateStateMachine>, IUpdateState, IFixedUpdateState, ILateUpdateState
    {
        public void Update() => _stateMachine.Update();
        public void FixedUpdate() => _stateMachine.FixedUpdate();
        public void LateUpdate() => _stateMachine.LateUpdate();
    }
}