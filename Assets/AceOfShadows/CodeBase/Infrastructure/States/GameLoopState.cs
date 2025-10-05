using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
  public class GameLoopState : IState
  {
    private readonly GameStateMachine _stateMachine;
    private readonly ITimeService _timeService;

    public GameLoopState(GameStateMachine stateMachine, ITimeService timeService)
    {
      _stateMachine = stateMachine;
      _timeService = timeService;
    }

    public void Enter()
    {
      _timeService.StartTicking();
    }
    public void Exit(){}
  }
}