using AceOfShadows.CodeBase.Infrastructure.States;
using UnityEngine;

namespace MagicWords.CodeBase.Infrustructure
{
  public class GameBootstrapper : MonoBehaviour 
  {
    private AceOfShadows.CodeBase.Infrastructure.Game _game;

    private void Awake()
    {
      _game = new AceOfShadows.CodeBase.Infrastructure.Game();
      _game.StateMachine.Enter<BootstrapState>();

      DontDestroyOnLoad(this);
    }
  }
}