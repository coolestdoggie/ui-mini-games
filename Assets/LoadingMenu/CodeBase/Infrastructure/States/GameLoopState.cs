using Common.States;
using LoadingMenu.CodeBase.Infrastructure.Services;
using LoadingMenu.CodeBase.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoadingMenu.CodeBase.Infrastructure.States
{
  public class GameLoopState : IState
  {
    private readonly LoadingMenuGameStateMachine _loadingMenuGameStateMachine;
    private readonly IGameFactory _gameFactory;
    private Menu _menu;

    public GameLoopState(LoadingMenuGameStateMachine loadingMenuGameStateMachine, IGameFactory gameFactory)
    {
      _loadingMenuGameStateMachine = loadingMenuGameStateMachine;
      _gameFactory = gameFactory;
    }

    public void Enter()
    {
      _menu = _gameFactory.Menu;
      _menu.AceOfShadowsGameButton.onClick.AddListener(SwitchToAceShadowsScene);
      _menu.MagicWordsGameButton.onClick.AddListener(SwitchToMagicWordsScene);
      _menu.PhoenixFlameGameButton.onClick.AddListener(SwitchToPhoenixFlameScene);
    }

    private void SwitchToScene(string sceneName)
    {
      SceneManager.LoadScene(sceneName);
      _loadingMenuGameStateMachine.Enter<EndState>();
    }
    private void SwitchToAceShadowsScene()
    {
      SceneManager.LoadScene("AceOfShadows");
    }
    
    private void SwitchToMagicWordsScene()
    {
      SceneManager.LoadScene("MagicWords");
    }

    private void SwitchToPhoenixFlameScene()
    {
    }

    public void Exit()
    {
      _menu.AceOfShadowsGameButton.onClick.RemoveListener(SwitchToAceShadowsScene);
      _menu.MagicWordsGameButton.onClick.RemoveListener(SwitchToMagicWordsScene);
      _menu.PhoenixFlameGameButton.onClick.RemoveListener(SwitchToPhoenixFlameScene);
    }
  }
}