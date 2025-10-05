using Common.Services;
using UnityEngine;

namespace Games.PhoenixFlame.CodeBase.Infrastructure.Services
{
  public interface IGameFactory: IService
  {
    Transform UiRoot { get; }
    void CreateUIRoot();
  }
}