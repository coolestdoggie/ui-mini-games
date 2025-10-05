using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
  public class GameLoopState : IState
  {
    private readonly GameStateMachine _stateMachine;
    private readonly ITimeService _timeService;
    private readonly ICardsService _cardsService;

    public GameLoopState(GameStateMachine stateMachine, ITimeService timeService, ICardsService cardsService)
    {
      _stateMachine = stateMachine;
      _timeService = timeService;
      _cardsService = cardsService;
    }

    public void Enter()
    {
      _timeService.StartTicking();
    }
    public void Exit(){}
  }
}