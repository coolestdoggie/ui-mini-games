using AceOfShadows.CodeBase.Infrastructure.States;
using UnityEngine;

namespace AceOfShadows.CodeBase.Infrastructure
{
  public class GameBootstrapper : MonoBehaviour 
  {
    private Game _game;

    private void Awake()
    {
      _game = new Game();
      _game.StateMachine.Enter<BootstrapState>();

      DontDestroyOnLoad(this);
    }
  }
}