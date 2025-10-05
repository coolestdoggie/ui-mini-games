using CodeBase.Services;
using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.States
{
  public class GameLoopState : IState
  {
    private readonly GameStateMachine _stateMachine;
    private readonly ITimeService _timeService;
    private readonly ICardsService _cardsService;
    private readonly IGameFactory _gameFactory;

    public GameLoopState(GameStateMachine stateMachine, ITimeService timeService, ICardsService cardsService,
      IGameFactory gameFactory)
    {
      _stateMachine = stateMachine;
      _timeService = timeService;
      _cardsService = cardsService;
      _gameFactory = gameFactory;
    }

    public void Enter()
    {
      _timeService.StartTicking();
      _cardsService.CardMovedToRightDeck += UpdateDeckCounterLabels;
      _cardsService.AllCardsMovedToRight += MoveToNextState;
    }

    private void MoveToNextState()
    {
      _stateMachine.Enter<EndState>();
    }

    public void Exit()
    {
      _cardsService.CardMovedToRightDeck -= UpdateDeckCounterLabels;
      _cardsService.AllCardsMovedToRight -= MoveToNextState;
    }

    private void UpdateDeckCounterLabels(int leftDeckCount, int rightDeckCount)
    {
      HudFacade hudFacade = _gameFactory.HudFacade;
      hudFacade.UpdateLeftDeckCounter(leftDeckCount);
      hudFacade.UpdateRightDeckCounter(rightDeckCount);
    }
  }
}