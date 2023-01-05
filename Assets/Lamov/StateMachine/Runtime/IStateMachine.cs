using Lamov.StateMachine.States;

namespace Lamov.StateMachine
{
    public interface IStateMachine
    {
        void AddState<TState>(TState state) where TState : class, IState;
        void Enter<TState>() where TState : class, IState;
    }
}