using Common.Services;
using MagicWords.CodeBase.UI;
using UnityEngine;

namespace MagicWords.CodeBase.Infrastructure.Services
{
  public interface IGameFactory: IService
  {
    public Transform UiRoot { get; }
    Transform ContentRoot { get; }
    void CreateUIRoot();
    DialogEntryView CreateDialogueEntry();
  }
}