using Common.States;
using Games.PhoenixFlame.CodeBase.Infrastructure.Services;

namespace Games.PhoenixFlame.CodeBase.Infrastructure.States
{
  public class LoadLevelState : IState
  {
    private readonly GameStateMachine _stateMachine;
    private readonly IGameFactory _gameFactory;

    public LoadLevelState(GameStateMachine gameStateMachine, IGameFactory gameFactory)
    {
      _stateMachine = gameStateMachine;
      _gameFactory = gameFactory;
    }

    public void Enter()
    {
      InitUIRoot();
      
      _stateMachine.Enter<GameLoopState>();
    }

    private void InitUIRoot()
    {
      _gameFactory.CreateUIRoot();
    }

    public void Exit() {}
  }
}