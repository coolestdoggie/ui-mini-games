using Common.Services;
using Common.States;
using LoadingMenu.CodeBase.Infrastructure.Services;

namespace LoadingMenu.CodeBase.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private readonly GameStateMachine _stateMachine;
    private readonly AllServices _services;

    public BootstrapState(GameStateMachine stateMachine, AllServices services)
    {
      _stateMachine = stateMachine;
      _services = services;

      RegisterServices();
    }

    public void Enter()
    {
      EnterLoadLevel();  
    }

    private void EnterLoadLevel()
    {
      _stateMachine.Enter<LoadLevelState>();
    }

    public void Exit() {}

    private void RegisterServices()
    {
      _services.RegisterSingle<IGameStateMachine>(_stateMachine);
      _services.RegisterSingle<IGameFactory>(new GameFactory());
    }
  }
}