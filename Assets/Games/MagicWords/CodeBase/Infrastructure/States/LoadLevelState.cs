using Common.States;
using Cysharp.Threading.Tasks;
using Games.MagicWords.CodeBase.Infrastructure.Services;

namespace Games.MagicWords.CodeBase.Infrastructure.States
{
  public class LoadLevelState : IState
  {
    private readonly GameStateMachine _stateMachine;
    private readonly IGameFactory _gameFactory;
    private readonly IDialogueFetchService _dialogueFetchService;
    private readonly IDialogueCreatorService _dialogueCreatorService;

    public LoadLevelState(GameStateMachine gameStateMachine, IGameFactory gameFactory,
      IDialogueFetchService dialogueFetchService, IDialogueCreatorService dialogueCreatorService)
    {
      _stateMachine = gameStateMachine;
      _gameFactory = gameFactory;
      _dialogueFetchService = dialogueFetchService;
      _dialogueCreatorService = dialogueCreatorService;
    }

    public void Enter()
    {
      InitUIRoot();
      InitLevel();
    }

    private void InitUIRoot()
    {
      _gameFactory.CreateUIRoot();
    }

    private async void InitLevel()
    {
      await FetchDialogueData();
      _dialogueCreatorService.CreateDialogue(_dialogueFetchService.Dialogues, _dialogueFetchService.NameByAvatarData);
    }

    private async UniTask FetchDialogueData()
    {
      await _dialogueFetchService.FetchDialogueDataAsync();
    }

    public void Exit() {}
  }
}