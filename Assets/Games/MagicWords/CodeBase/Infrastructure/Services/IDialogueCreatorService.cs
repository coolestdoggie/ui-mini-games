using System.Collections.Generic;
using Common.Services;
using Games.MagicWords.CodeBase.Data;

namespace Games.MagicWords.CodeBase.Infrastructure.Services
{
  public interface IDialogueCreatorService : IService
  {
    void CreateDialogue(List<DialogueEntry> dialogues, Dictionary<string, AvatarData> nameByAvatarData);
  }
}