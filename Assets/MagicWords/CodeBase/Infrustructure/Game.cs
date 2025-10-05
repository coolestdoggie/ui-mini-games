using Common.Services;
using Common.States;
using MagicWords.CodeBase.Infrustructure.States;

namespace MagicWords.CodeBase.Infrustructure
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