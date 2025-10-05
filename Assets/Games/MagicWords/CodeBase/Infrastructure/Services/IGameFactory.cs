using Common.Services;
using Games.MagicWords.CodeBase.UI;
using UnityEngine;

namespace Games.MagicWords.CodeBase.Infrastructure.Services
{
  public interface IGameFactory: IService
  {
    public Transform UiRoot { get; }
    Transform ContentRoot { get; }
    void CreateUIRoot();
    DialogEntryView CreateDialogueEntry();
  }
}