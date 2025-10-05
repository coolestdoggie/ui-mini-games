using CodeBase.Services;
using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.States
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
      _services.RegisterSingle<IConfigsService>(new ConfigsService());
      _services.RegisterSingle<ITimeService>(new TimeService());
      _services.RegisterSingle<IGameFactory>(new GameFactory());
      _services.RegisterSingle<ICardsService>(new CardsService(_services.Single<IGameFactory>(),
        _services.Single<ITimeService>(), _services.Single<IConfigsService>()));
    }
  }
}