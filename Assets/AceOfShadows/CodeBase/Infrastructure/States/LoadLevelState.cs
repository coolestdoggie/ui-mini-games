using AceOfShadows.CodeBase.Infrastructure.Services;
using AceOfShadows.CodeBase.UI;
using AceOfShadows.CodeBase.UI.Services.Factory;
using Common.States;

namespace AceOfShadows.CodeBase.Infrastructure.States
{
  public class LoadLevelState : IState
  {
    private readonly GameStateMachine _stateMachine;
    private readonly IConfigsService _configsService;
    private readonly IGameFactory _gameFactory;
    private readonly ICardsService _cardsService;

    public LoadLevelState(GameStateMachine gameStateMachine, IConfigsService configsService, IGameFactory gameFactory, ICardsService cardsService)
    {
      _stateMachine = gameStateMachine;
      _configsService = configsService;
      _gameFactory = gameFactory;
      _cardsService = cardsService;
    }

    public void Enter()
    {
      InitUIRoot();
      InitScene(); 
    }

    private void InitUIRoot() => 
      _gameFactory.CreateUIRoot();

    private void InitScene()
    {
      InitConfigs();
      InitHud();
      InitDecks();
      UpdateHudState();

      _stateMachine.Enter<GameLoopState>();
    }

    private void InitConfigs() =>
      _configsService.LoadConfigs();

    private void InitHud()
    {
      _gameFactory.CreateHud();
      _gameFactory.HudFacade.transform.SetParent(_gameFactory.UiRoot, false);
    }

    private void InitDecks() =>
      _cardsService.Init();

    private void UpdateHudState()
    {
      HudFacade hudFacade = _gameFactory.HudFacade;
      hudFacade.UpdateLeftDeckCounter(_cardsService.LeftDeckCardsAmount);
      hudFacade.UpdateRightDeckCounter(_cardsService.RightDeckCardsAmount);
    }

    public void Exit() {}
  }
}