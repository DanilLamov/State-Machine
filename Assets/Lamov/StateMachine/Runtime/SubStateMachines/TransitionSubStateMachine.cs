using Lamov.StateMachine.Runtime.States;
using Lamov.StateMachine.Runtime.TransitionStateMachineModule;

namespace Lamov.StateMachine.Runtime.SubStateMachines
{
    public class TransitionSubStateMachine : SimpleSubStateMachine<TransitionStateMachine>, IUpdateState, IFixedUpdateState, ILateUpdateState
    {
        public virtual void Update() => _stateMachine.Update();
        public virtual void FixedUpdate() => _stateMachine.FixedUpdate();
        public virtual void LateUpdate() => _stateMachine.LateUpdate();
    }
}