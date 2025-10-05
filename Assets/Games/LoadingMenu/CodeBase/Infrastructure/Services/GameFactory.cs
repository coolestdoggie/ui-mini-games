using Games.LoadingMenu.CodeBase.UI;
using UnityEngine;

namespace Games.LoadingMenu.CodeBase.Infrastructure.Services
{
  public class GameFactory : IGameFactory
  {
    private const string UIRootPath = "LoadingMenu/UIRoot";
    private const string MenuPath = "LoadingMenu/Menu";
    public Transform UiRoot { get; private set; }
    public Menu Menu { get; private set; }

    public void CreateUIRoot()
    {
      GameObject rootPrefab = Resources.Load<GameObject>(UIRootPath);
      GameObject root = Object.Instantiate(rootPrefab);
      
      UiRoot = root.transform;
    }

    public void CreateMenu()
    {
      GameObject menuPath = Resources.Load<GameObject>(MenuPath);
      GameObject menu = Object.Instantiate(menuPath);
      
      Menu = menu.GetComponent<Menu>();
    }
  }
}