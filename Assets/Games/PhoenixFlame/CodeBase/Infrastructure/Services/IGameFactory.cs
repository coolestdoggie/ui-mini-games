using Common.Services;
using Games.PhoenixFlame.CodeBase.UI;
using UnityEngine;

namespace Games.PhoenixFlame.CodeBase.Infrastructure.Services
{
  public interface IGameFactory: IService
  {
    void CreateFire();
    void CreateUIRoot();
    UIRoot UiRoot { get; }
    GameObject Fire { get; }
  }
}