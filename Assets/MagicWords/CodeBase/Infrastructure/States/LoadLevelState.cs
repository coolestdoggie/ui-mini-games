using Common.States;
using MagicWords.CodeBase.Infrastructure.Services;

namespace MagicWords.CodeBase.Infrastructure.States
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
    }

    private void InitUIRoot()
    {
      _gameFactory.CreateUIRoot();
    }

    private void InitLevel()
    {

      // _stateMachine.Enter<GameLoopState>();
    }

    public void Exit() {}
  }
}