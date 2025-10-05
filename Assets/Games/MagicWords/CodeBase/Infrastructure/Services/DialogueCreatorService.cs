using System.Collections.Generic;
using Games.MagicWords.CodeBase.Data;
using Games.MagicWords.CodeBase.UI;
using Transform = UnityEngine.Transform;

namespace Games.MagicWords.CodeBase.Infrastructure.Services
{
  public class DialogueCreatorService : IDialogueCreatorService
  {
    private readonly IGameFactory _gameFactory;
    private readonly IEmojiTranslaterService _emojiTranslaterService;
    private List<DialogueEntry> _dialogues;
    private Dictionary<string, AvatarData> _nameByAvatarData;

    public DialogueCreatorService(IGameFactory gameFactory, IEmojiTranslaterService emojiTranslaterService)
    {
      _gameFactory = gameFactory;
      _emojiTranslaterService = emojiTranslaterService;
    }

    public void CreateDialogue(List<DialogueEntry> dialogues, Dictionary<string, AvatarData> nameByAvatarData)
    {
      _dialogues = dialogues;
      _nameByAvatarData = nameByAvatarData;

      Transform contentRoot = _gameFactory.ContentRoot;

      foreach (DialogueEntry entry in dialogues)
      {
        if (string.IsNullOrEmpty(entry.name) || string.IsNullOrEmpty(entry.text))
          continue;

        InitDialogueEntryView(entry);
      }
    }

    private void InitDialogueEntryView(DialogueEntry entry)
    {
      DialogEntryView dialogEntryView = _gameFactory.CreateDialogueEntry();

      var avatarDataExists = _nameByAvatarData.TryGetValue(entry.name, out AvatarData avatarData);
      if (avatarDataExists)
      {
        dialogEntryView.SetAvatar(avatarData.sprite);
        dialogEntryView.SetPositioningRightSide(avatarData.PositionedRight);
      }
      
      dialogEntryView.SetName(entry.name);
      
      string processedMessage = _emojiTranslaterService.ReplaceEmojis(entry.text);
      dialogEntryView.SetMessage(processedMessage);
    }
  }
}