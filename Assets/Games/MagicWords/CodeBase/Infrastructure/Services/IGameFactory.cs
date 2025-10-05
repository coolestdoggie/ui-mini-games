using Common.Services;
using Games.MagicWords.CodeBase.UI;
using UnityEngine;

namespace Games.MagicWords.CodeBase.Infrastructure.Services
{
  public interface IGameFactory: IService
  {
    void CreateUIRoot();
    DialogEntryView CreateDialogueEntry();
  }
}