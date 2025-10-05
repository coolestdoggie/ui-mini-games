using CodeBase.UI.Services.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.States
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
      // hud.GetComponentInChildren<ActorUI>().Construct(_hero.GetComponent<HeroHealth>(), _scoreCounter);
    }

    private void InitLeftDeck()
    {
      const float yOffset = 12;
      float currentOffset = 0;
      for (int i = 0; i < 10; i++)
      {
        GameObject card = _gameFactory.CreateCard();
        card.transform.SetParent(_gameFactory.HudFacade.LeftDeckTransform, false);
        card.transform.localPosition = new Vector3(0, card.transform.localPosition.y - currentOffset, 0);

        currentOffset += yOffset;
      }
    }
    
    public void Exit()
    {
      
    }
    
  }
}