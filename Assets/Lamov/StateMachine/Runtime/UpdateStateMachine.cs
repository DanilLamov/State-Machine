using Lamov.StateMachine.States;

namespace Lamov.StateMachine
{
    public class UpdateStateMachine : SimpleStateMachine
    {
        public void Update()
        {
            if (_activeState is IUpdateState updateState) updateState.Update();
        }
    }
}