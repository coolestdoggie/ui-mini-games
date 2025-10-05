using Common.Services;
using Games.LoadingMenu.CodeBase.UI;
using UnityEngine;

namespace Games.LoadingMenu.CodeBase.Infrastructure.Services
{
  public interface IGameFactory: IService
  {
    Transform UiRoot { get; }
    Menu Menu { get; }
    void CreateUIRoot();
    void CreateMenu();
  }
}