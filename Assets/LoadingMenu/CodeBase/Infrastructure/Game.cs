using Common.Services;
using Common.States;
using LoadingMenu.CodeBase.Infrastructure.States;

namespace LoadingMenu.CodeBase.Infrastructure
{
  public class Game
  {
    public GameStateMachine StateMachine;

    public Game()
    {
      StateMachine = new LoadingMenuGameStateMachine(AllServices.Container);
    }
  }
}