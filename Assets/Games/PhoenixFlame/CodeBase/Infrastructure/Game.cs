using Common.Services;
using Common.States;
using Games.PhoenixFlame.CodeBase.Infrastructure.States;

namespace Games.PhoenixFlame.CodeBase.Infrastructure
{
  public class Game
  {
    public GameStateMachine StateMachine;

    public Game()
    {
      StateMachine = new PhoenixFlameGameStateMachine(AllServices.Container);
    }
  }
}