using System.Collections.Generic;
using Common.Services;
using Cysharp.Threading.Tasks;
using MagicWords.CodeBase.Data;

namespace MagicWords.CodeBase.Infrastructure.Services
{
  public interface IDialogueFetchService : IService
  {
    Dictionary<string, AvatarData> NameByAvatarData { get; }
    List<DialogueEntry> Dialogues { get; }
    UniTask FetchDialogueDataAsync();
  }
}