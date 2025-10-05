using Common.Services;
using Common.States;
using Games.LoadingMenu.CodeBase.Infrastructure.States;

namespace Games.LoadingMenu.CodeBase.Infrastructure
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