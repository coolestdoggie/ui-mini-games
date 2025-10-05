using Common.States;
using Games.PhoenixFlame.CodeBase.Infrastructure.Services;

namespace Games.PhoenixFlame.CodeBase.Infrastructure.States
{
  public class GameLoopState : IState
  {
    private readonly PhoenixFlameGameStateMachine _phoenixFlameGameStateMachine;
    private readonly IGameFactory _gameFactory;

    public GameLoopState(PhoenixFlameGameStateMachine phoenixFlameGameStateMachine, IGameFactory gameFactory)
    {
      _phoenixFlameGameStateMachine = phoenixFlameGameStateMachine;
      _gameFactory = gameFactory;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }
  }
}