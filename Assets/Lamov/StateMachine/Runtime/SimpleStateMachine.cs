using System;
using System.Collections.Generic;
using Lamov.StateMachine.States;

public class SimpleStateMachine
{
    protected Dictionary<Type, IState> _states;
    protected IState _activeState;

    public SimpleStateMachine()
    {
        _states = new Dictionary<Type, IState>();
    }
    
    public void AddState<TState>(TState state) where TState : class, IState
    {
        _states.Add(state.GetType(), state);
    }
    
    public void Enter<TState>() where TState : class, IState
    {
        var state = ChangeState<TState>();

        if (state is IStateEnter enterState)
        {
            enterState.OnStateEnter();
        }
    }

    private TState ChangeState<TState>() where TState : class, IState
    {
        if (_activeState is IStateExit exitState)
        {
            exitState.OnStateExit();
        } 

        var state = GetState<TState>();
        _activeState = state;

        return state;
    }

    private TState GetState<TState>() where TState : class, IState => _states[typeof(TState)] as TState;
}
