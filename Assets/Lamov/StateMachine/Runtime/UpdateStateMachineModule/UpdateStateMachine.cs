using Lamov.StateMachine.Runtime.States;

namespace Lamov.StateMachine.Runtime.UpdateStateMachineModule
{
    public class UpdateStateMachine : SimpleStateMachine
    {
        public virtual void Update()
        {
            if (ActiveState is IUpdateState updateState) updateState.Update();
        }

        public virtual void FixedUpdate()
        {
            if (ActiveState is IFixedUpdateState fixedUpdateState) fixedUpdateState.FixedUpdate();
        }

        public virtual void LateUpdate()
        {
            if (ActiveState is ILateUpdateState lateUpdateState) lateUpdateState.LateUpdate();
        }
    }
}