using AceOfShadows.CodeBase.Infrastructure.Services;
using Common.Services;
using UnityEngine;

namespace AceOfShadows.CodeBase.UI.Services.Factory
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