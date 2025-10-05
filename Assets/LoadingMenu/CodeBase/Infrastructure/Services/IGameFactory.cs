using Common.Services;
using LoadingMenu.CodeBase.UI;
using UnityEngine;

namespace LoadingMenu.CodeBase.Infrastructure.Services
{
  public interface IGameFactory: IService
  {
    Transform UiRoot { get; }
    Menu Menu { get; }
    void CreateUIRoot();
    void CreateMenu();
  }
}