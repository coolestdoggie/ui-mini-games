using AceOfShadows.CodeBase.Infrastructure.Services;
using AceOfShadows.CodeBase.Infrastructure.States;
using Common.Services;

namespace Common.States
{
  public interface IGameStateMachine : IService
  {
    void Enter<TState>() where TState : class, IState;
    void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
  }
}