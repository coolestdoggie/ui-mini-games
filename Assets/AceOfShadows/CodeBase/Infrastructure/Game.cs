using AceOfShadows.CodeBase.Infrastructure.Services;
using AceOfShadows.CodeBase.Infrastructure.States;

namespace AceOfShadows.CodeBase.Infrastructure
{
  public class Game
  {
    public GameStateMachine StateMachine;

    public Game()
    {
      StateMachine = new GameStateMachine(AllServices.Container);
    }
  }
}