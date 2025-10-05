using System.Collections.Generic;
using Common.Services;
using MagicWords.CodeBase.Data;

namespace MagicWords.CodeBase.Infrastructure.Services
{
  public interface IDialogueCreatorService : IService
  {
    void CreateDialogue(List<DialogueEntry> dialogues, Dictionary<string, AvatarData> nameByAvatarData);
  }
}