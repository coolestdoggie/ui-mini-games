using CodeBase.Services;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
  public interface IGameFactory: IService
  {
    public Transform UiRoot { get; }
    HudFacade HudFacade { get; }
    void CreateUIRoot();
    void CreateHud();
    GameObject CreateCard();
  }
}