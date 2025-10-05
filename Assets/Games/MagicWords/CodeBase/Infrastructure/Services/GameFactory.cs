using Games.MagicWords.CodeBase.UI;
using UnityEngine;

namespace Games.MagicWords.CodeBase.Infrastructure.Services
{
  public class GameFactory : IGameFactory
  {
    private const string UIRootPath = "MagicWords/UIRoot";
    private const string DialogueEntry = "MagicWords/DialogueEntry";
    private Transform _contentRoot; 

    public void CreateUIRoot()
    {
      GameObject rootPrefab = Resources.Load<GameObject>(UIRootPath);
      GameObject root = Object.Instantiate(rootPrefab);
      _contentRoot = root.GetComponent<UIRoot>().ContentRoot;
    }

    public DialogEntryView CreateDialogueEntry()
    {
      GameObject dialogueEntryPrefab = Resources.Load<GameObject>(DialogueEntry);
      GameObject dialogueEntry = Object.Instantiate(dialogueEntryPrefab, _contentRoot, true);
      return dialogueEntry.GetComponent<DialogEntryView>();
    }
    
  }
}