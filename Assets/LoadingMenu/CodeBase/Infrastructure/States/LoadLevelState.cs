using Common.States;
using LoadingMenu.CodeBase.Infrastructure.Services;

namespace LoadingMenu.CodeBase.Infrastructure.States
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
      InitMenu();
      
      _stateMachine.Enter<GameLoopState>();
    }

    private void InitMenu()
    {
      _gameFactory.CreateMenu();
      _gameFactory.Menu.gameObject.transform.SetParent(_gameFactory.UiRoot, false);
    }

    private void InitUIRoot()
    {
      _gameFactory.CreateUIRoot();
    }

    public void Exit() {}
  }
}