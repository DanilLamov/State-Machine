using Lamov.StateMachine.States;

namespace Lamov.StateMachine.Runtime.UpdateStateMachineModule
{
    public class UpdateStateMachine : SimpleStateMachine
    {
        public virtual void Update()
        {
            if (_activeState is IUpdateState updateState) updateState.Update();
        }
    }
}