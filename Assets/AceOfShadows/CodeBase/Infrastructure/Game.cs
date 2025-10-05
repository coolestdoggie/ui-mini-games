using AceOfShadows.CodeBase.Infrastructure.Services;
using AceOfShadows.CodeBase.Infrastructure.States;
using Common.Services;
using Common.States;

namespace AceOfShadows.CodeBase.Infrastructure
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