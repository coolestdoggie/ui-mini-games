using UnityEngine;

namespace Games.PhoenixFlame.CodeBase.Infrastructure.Services
{
  public class GameFactory : IGameFactory
  {
    private const string UIRootPath = "PhoenixFlame/UIRoot";
    public Transform UiRoot { get; private set; }

    public void CreateUIRoot()
    {
      GameObject rootPrefab = Resources.Load<GameObject>(UIRootPath);
      GameObject root = Object.Instantiate(rootPrefab);
      
      UiRoot = root.transform;
    }
  }
}