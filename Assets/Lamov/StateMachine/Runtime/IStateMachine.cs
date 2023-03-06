using Lamov.StateMachine.Runtime.States;

namespace Lamov.StateMachine.Runtime
{
    public interface IStateMachine
    {
        void AddState<TState>(TState state) where TState : class, IState;
        void Enter<TState>() where TState : class, IState;
    }
}