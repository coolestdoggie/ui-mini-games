using CodeBase.Services;
using CodeBase.UI.Services.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
  public class LoadLevelState : IState
  {
    private readonly GameStateMachine _stateMachine;
    private readonly IGameFactory _gameFactory;
    private readonly ICardsService _cardsService;

    public LoadLevelState(GameStateMachine gameStateMachine, IGameFactory gameFactory, ICardsService cardsService)
    {
      _stateMachine = gameStateMachine;
      _gameFactory = gameFactory;
      _cardsService = cardsService;
    }

    public void Enter()
    {
      InitUIRoot();
      InitLevel(); 
    }

    private void InitUIRoot() => 
      _gameFactory.CreateUIRoot();

    private void InitLevel()
    {
      InitHud();
      InitLeftDeck();

      _stateMachine.Enter<GameLoopState>();
    }

    private void InitHud()
    {
      _gameFactory.CreateHud();
      HudFacade hudFacade = _gameFactory.HudFacade;
      hudFacade.transform.SetParent(_gameFactory.UiRoot, false);
    }

    private void InitLeftDeck()
    {
      _cardsService.CreateLeftDeck();
    }
    
    public void Exit()
    {
      
    }
    
  }
}