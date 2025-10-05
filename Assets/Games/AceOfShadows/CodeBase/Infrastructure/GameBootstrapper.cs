using Games.AceOfShadows.CodeBase.Infrastructure.States;
using UnityEngine;

namespace Games.AceOfShadows.CodeBase.Infrastructure
{
  public class GameBootstrapper : MonoBehaviour 
  {
    private Game _game;

    private void Awake()
    {
      _game = new Game();
      _game.StateMachine.Enter<BootstrapState>();
    }
  }
}