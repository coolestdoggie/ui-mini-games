using UnityEngine;

namespace AceOfShadows.CodeBase.UI.Services.Factory
{
  public class GameFactory : IGameFactory
  {
    private const string UIRootPath = "AceOfShadows/UIRoot";
    private const string HudPath = "AceOfShadows/Hud";
    private const string CardPath = "AceOfShadows/Card";
    public Transform UiRoot { get; private set; }
    public HudFacade HudFacade { get; private set; }

    public void CreateUIRoot()
    {
      GameObject rootPrefab = Resources.Load<GameObject>(UIRootPath);
      GameObject root = Object.Instantiate(rootPrefab);
      UiRoot = root.transform;
    }

    public void CreateHud()
    {
      GameObject hudPrefab = Resources.Load<GameObject>(HudPath);
      HudFacade hud = Object.Instantiate(hudPrefab).GetComponent<HudFacade>();
      HudFacade = hud;
    }

    public GameObject CreateCard()
    {
      GameObject cardPrefab = Resources.Load<GameObject>(CardPath);
      GameObject card = Object.Instantiate(cardPrefab);
      
      return card;
    }
  }
}