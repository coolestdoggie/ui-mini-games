using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
  public class GameFactory : IGameFactory
  {
    private const string UIRootPath = "AceOfShades/UIRoot";
    private const string HudPath = "AceOfShades/Hud";
    private const string CardPath = "AceOfShades/Card";
    public Transform UiRoot { get; private set; }
    public HudFacade HudFacade { get; private set; }

    public void CreateUIRoot()
    {
      GameObject rootPrefab = Resources.Load(UIRootPath) as GameObject;
      GameObject root = Object.Instantiate(rootPrefab);
      UiRoot = root.transform;
    }

    public void CreateHud()
    {
      GameObject hudPrefab = Resources.Load(HudPath) as GameObject;
      HudFacade hud = Object.Instantiate(hudPrefab).GetComponent<HudFacade>();
      HudFacade = hud;
    }

    public GameObject CreateCard()
    {
      GameObject cardPrefab = Resources.Load(CardPath) as GameObject;
      GameObject card = Object.Instantiate(cardPrefab);
      
      return card;
    }
  }
}