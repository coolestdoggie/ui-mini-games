using Common.Services;
using Common.States;
using Games.AceOfShadows.CodeBase.Infrastructure.States;

namespace Games.AceOfShadows.CodeBase.Infrastructure
{
  public class Game
  {
    public GameStateMachine StateMachine;

    public Game()
    {
      StateMachine = new AceOfShadowsGameStateMachine(AllServices.Container);
    }
  }
}