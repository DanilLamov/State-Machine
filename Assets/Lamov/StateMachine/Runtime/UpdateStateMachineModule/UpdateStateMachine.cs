using Lamov.StateMachine.Runtime.States;

namespace Lamov.StateMachine.Runtime.UpdateStateMachineModule
{
    public class UpdateStateMachine : SimpleStateMachine
    {
        public virtual void Update()
        {
            if (ActiveState is IUpdateState updateState) updateState.Update();
        }
    }
}