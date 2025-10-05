using Common.Services;
using Common.States;
using Games.MagicWords.CodeBase.Infrastructure.States;

namespace Games.MagicWords.CodeBase.Infrastructure
{
  public class Game
  {
    public GameStateMachine StateMachine;

    public Game()
    {
      StateMachine = new MagicWordsGameStateMachine(AllServices.Container);
    }
  }
}