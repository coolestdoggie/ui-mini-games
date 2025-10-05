using Games.PhoenixFlame.CodeBase.UI;
using UnityEngine;

namespace Games.PhoenixFlame.CodeBase.Infrastructure.Services
{
  public class GameFactory : IGameFactory
  {
    private const string FireVFXPath = "PhoenixFlame/VFX_Fire";
    private const string UIRootPath = "PhoenixFlame/UIRoot";
    public UIRoot UiRoot { get; private set; }
    public GameObject Fire { get; private set; }
    
    
    public void CreateUIRoot()
    {
      GameObject rootPrefab = Resources.Load<GameObject>(UIRootPath);
      GameObject root = Object.Instantiate(rootPrefab);
      UiRoot = root.GetComponent<UIRoot>();
    }
    
    public void CreateFire()
    {
      GameObject firePrefab = Resources.Load<GameObject>(FireVFXPath);
      Fire = Object.Instantiate(firePrefab);
    }
  }
}