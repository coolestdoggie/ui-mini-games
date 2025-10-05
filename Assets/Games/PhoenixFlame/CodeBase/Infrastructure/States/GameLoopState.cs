using Common.States;
using Games.PhoenixFlame.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace Games.PhoenixFlame.CodeBase.Infrastructure.States
{
  public class GameLoopState : IState
  {
    private static readonly int ChangeColor = Animator.StringToHash("ChangeColor");
    
    private readonly PhoenixFlameGameStateMachine _phoenixFlameGameStateMachine;
    private readonly IGameFactory _gameFactory;
    
    private Animator _fireAnimator;

    public GameLoopState(PhoenixFlameGameStateMachine phoenixFlameGameStateMachine, IGameFactory gameFactory)
    {
      _phoenixFlameGameStateMachine = phoenixFlameGameStateMachine;
      _gameFactory = gameFactory;
    }

    public void Enter()
    {
      _fireAnimator = _gameFactory.Fire.GetComponent<Animator>();
      _gameFactory.UiRoot.ChangeFireColorButton.onClick.AddListener(ChangeFireColor);
    }
    
    private void ChangeFireColor()
    {
      _fireAnimator.SetTrigger(ChangeColor);
    }

    public void Exit()
    {
      _gameFactory.UiRoot.ChangeFireColorButton.onClick.RemoveListener(ChangeFireColor);
    }
  }
}