using Common.States;
using Games.LoadingMenu.CodeBase.Infrastructure.Services;
using Games.LoadingMenu.CodeBase.UI;
using UnityEngine.SceneManagement;

namespace Games.LoadingMenu.CodeBase.Infrastructure.States
{
  public class GameLoopState : IState
  {
    private const string AceOfShadowsSceneName = "AceOfShadows";
    private const string MagicWordsSceneName = "MagicWords";
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

  private void SwitchToAceShadowsScene()
    {
      SceneManager.LoadScene(AceOfShadowsSceneName);
      _loadingMenuGameStateMachine.Enter<EndState>();
    }
    
    private void SwitchToMagicWordsScene()
    {
      SceneManager.LoadScene(MagicWordsSceneName);
      _loadingMenuGameStateMachine.Enter<EndState>();
    }

    private void SwitchToPhoenixFlameScene()
    {
      _loadingMenuGameStateMachine.Enter<EndState>();
    }

    public void Exit()
    {
      _menu.AceOfShadowsGameButton.onClick.RemoveListener(SwitchToAceShadowsScene);
      _menu.MagicWordsGameButton.onClick.RemoveListener(SwitchToMagicWordsScene);
      _menu.PhoenixFlameGameButton.onClick.RemoveListener(SwitchToPhoenixFlameScene);
    }
  }
}