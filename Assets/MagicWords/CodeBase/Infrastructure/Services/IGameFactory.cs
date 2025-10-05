using Common.Services;
using UnityEngine;

namespace MagicWords.CodeBase.Infrastructure.Services
{
  public interface IGameFactory: IService
  {
    public Transform UiRoot { get; }
    void CreateUIRoot();
  }
}