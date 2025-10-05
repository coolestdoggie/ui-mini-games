using System;
using System.Collections.Generic;
using AceOfShadows.CodeBase.Infrastructure.Services;
using AceOfShadows.CodeBase.Infrastructure.States;
using Common.Services;

namespace Common.States
{
  public abstract class GameStateMachine : IGameStateMachine
  {
    protected Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    protected GameStateMachine(AllServices services)
    {
      InitializeStates(services);
    }

    protected abstract void InitializeStates(AllServices services);

    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    {
      TState state = ChangeState<TState>();
      state.Enter(payload);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
      _activeState?.Exit();
      
      TState state = GetState<TState>();
      _activeState = state;
      
      return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState => 
      _states[typeof(TState)] as TState;
  }
}